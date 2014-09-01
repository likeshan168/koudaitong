using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.Linq;
using Newtonsoft.Json.Linq;
namespace KouDaiTong.Models
{
    public class LogicModel
    {
        private KDTApiKit kit = null;
        private Dictionary<String, String> param = null;
        Dictionary<string, object> postParameters = null;
        private DataClassesDataContext dataContext = null;
        private string result = string.Empty;
        public LogicModel()
        {
            kit = new KDTApiKit("a698727f1934c56c4a", "6ac1c2d1bf5c6ce40bee0f34fe6ad3a6");
            param = new Dictionary<String, String>();//参数
            postParameters = new Dictionary<string, object>();//文件参数
        }
        /// <summary>
        /// 获取商品分类二维列表
        /// </summary>
        /// <returns></returns>
        public IList<ItemCategory> GetItemCategories()
        {
            IList<ItemCategory> cts = null;
            if (HttpContext.Current.Cache["item_categories"] == null)
            {
                result = kit.get(MethodNameModel.GET_ITEM_CATEGORIES, param);
                ItemCategoryResult rst = JsonConvert.DeserializeObject<ItemCategoryResult>(result);
                cts = rst.response.categories;
                HttpContext.Current.Cache["item_categories"] = cts;
                return cts;
            }
            else
            {
                cts = (ItemCategory[])HttpContext.Current.Cache["item_categories"];
                return cts;
            }
        }
        /// <summary>
        /// 获取商品子类
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ItemCategory[] GetSubItemCategories(int pcid)
        {
            IList<ItemCategory> cts = GetItemCategories();//获取总的
            return cts.Where(p => p.cid == pcid).FirstOrDefault().sub_categories;

        }



        /// <summary>
        /// 获取商品推广栏目列表
        /// </summary>
        /// <returns></returns>
        public IList<ItemPromotionCategory> GetItemPromotionCategories()
        {

            IList<ItemPromotionCategory> cts = null;
            if (HttpContext.Current.Cache["item_promotion"] == null)
            {
                result = kit.get(MethodNameModel.GET_ITEM_CATEGORIES_PROMOTIONS, param);
                ItemPromotionCategoryResult rst = JsonConvert.DeserializeObject<ItemPromotionCategoryResult>(result);
                cts = rst.response.categories;
                return cts;
            }
            else
            {
                cts = (ItemPromotionCategory[])HttpContext.Current.Cache["item_promotion"];
                return cts;
            }


        }
        /// <summary>
        /// 获取商品自定义标签列表
        /// </summary>
        /// <returns></returns>
        public IList<ItemTag> GetItemCategoryTags()
        {

            IList<ItemTag> cts = null;
            if (HttpContext.Current.Cache["item_tags"] == null)
            {
                result = kit.get(MethodNameModel.GET_ITEM_CATEGORIES_TAGS, param);
                ItemTagResult rst = JsonConvert.DeserializeObject<ItemTagResult>(result);
                cts = rst.response.tags;
                return cts;
            }
            else
            {
                cts = (ItemTag[])HttpContext.Current.Cache["item_tags"];
                return cts;
            }

        }
        /// <summary>
        /// 将商品分类，推广，以及标签合并在一起
        /// </summary>
        /// <returns></returns>
        public CategoriesAndTags HeBing()
        {
            CategoriesAndTags cat = new CategoriesAndTags();
            cat.ItemCategories = GetItemCategories();
            cat.ItemPromotionCategories = GetItemPromotionCategories();
            cat.ItemTags = GetItemCategoryTags();
            return cat;
        }
        /// <summary>
        /// 获取产品库存信息表
        /// </summary>
        /// <returns></returns>
        public IList<kdt_style_kucun_procResult> GetProductInfos(string searchT, string searchV, int page, out int total)
        {

            using (dataContext = new DataClassesDataContext())
            {
                #region
                //return (from q in dataContext.kucun_kdt_view
                //            group q by new { q.Com_nm, q.Sty_no } into g
                //            select new StyleInfo
                //            {
                //                Style_Name=g.Key.Com_nm,
                //                Style_No = g.Key.Sty_no,
                //                Count = g.Sum(p => p.Com_qu)
                //            }).OrderBy(p=>p.Style_No).Skip(0).Take(10).ToList(); 
                #endregion
                IMultipleResults query = null;
                switch (searchT)
                {
                    case "1"://按款式查询
                        query = dataContext.kdt_style_kucun_proc2(searchV, string.Empty, 0, 1, page);
                        break;
                    case "2"://按名称查询
                        query = dataContext.kdt_style_kucun_proc2(string.Empty, searchV, 0, 2, page);
                        break;
                    case "3"://按库存数查询
                        query = dataContext.kdt_style_kucun_proc2(string.Empty, string.Empty, Convert.ToDecimal(searchV), 3, page);
                        break;
                    default://查询所有
                        query = dataContext.kdt_style_kucun_proc2(string.Empty, string.Empty, 0, 4, page);
                        break;

                }

                var kucun = query.GetResult<kdt_style_kucun_procResult>().ToList();
                if (page == 1)
                {
                    HttpContext.Current.Cache.Remove("total");
                }

                if (HttpContext.Current.Cache["total"] == null)
                {

                    total = query.GetResult<int>().FirstOrDefault();
                    HttpContext.Current.Cache["total"] = total;
                }
                else
                {
                    total = (int)HttpContext.Current.Cache["total"];
                }

                return kucun;
                //.Skip((page-1)*10).Take(10).ToList();
            }
        }

        /// <summary>
        /// 获取指定款式
        /// </summary>
        /// <param name="styleNo">款式号</param>
        /// <returns></returns>
        public IList<kucun_kdt_view> GetDetails(string styleNo)
        {
            using (dataContext = new DataClassesDataContext())
            {
                return dataContext.kucun_kdt_view.Where(p => p.Sty_no == styleNo).ToList();
            }
        }
        /// <summary>
        /// 将数据发送给口袋通的接口
        /// </summary>
        /// <param name="item">包含的所有的参数数据</param>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public string PostProductItem(ProductItem item, HttpFileCollectionBase files)
        {

            param.Add("cid", item.cid.ToString());
            param.Add("promotion_cid", item.promotion_cid.ToString());
            param.Add("tag_ids", item.tag_ids.ToString());

            if (!string.IsNullOrEmpty(item.title))
                param.Add("title", item.title);
            else
                return "商品标题不能为空!";
            if (!string.IsNullOrEmpty(item.desc))
            {
                param.Add("desc", item.desc);
            }
            else
            {
                return "商品描述!";
            }
            if (item.price < 0.01d || item.price > 100000000)//
            {
                return "商品价格不符合要求";
            }
            else
            {
                param.Add("price", item.price.ToString());
            }

            int fileCount = files.Count;
            if (fileCount == 0)
            {
                return "请选择商品图片";
            }


            param.Add("is_virtual", item.is_virtual.ToString());
            param.Add("post_fee", item.post_fee.ToString());

            if (!string.IsNullOrEmpty(item.sku_properties))
            {
                param.Add("sku_properties", item.sku_properties);
            }
            else
            {
                return "请选择要发布的SKU";
            }
            if (!string.IsNullOrEmpty(item.sku_quantities))
            {
                param.Add("sku_quantities", item.sku_quantities);
            }
            else
            {
                return "请选择要发布的SKU";
            }
            if (!string.IsNullOrEmpty(item.sku_prices))
            {
                param.Add("sku_prices", item.sku_prices);
            }
            else
            {
                return "请选择要发布的SKU";
            }
            if (!string.IsNullOrEmpty(item.sku_outer_ids))
            {
                param.Add("sku_outer_ids", item.sku_outer_ids);
            }
            else
            {
                return "请选择要发布的SKU";
            }
            if (!string.IsNullOrEmpty(item.origin_price))
            {
                param.Add("origin_price", item.origin_price);
            }
            if (!string.IsNullOrEmpty(item.buy_url))
            {
                param.Add("buy_url", item.buy_url);
            }
            if (!string.IsNullOrEmpty(item.outer_id))
            {
                param.Add("outer_id", item.outer_id);
            }

            param.Add("buy_quota", item.buy_quota.ToString());


            param.Add("hide_quantity", item.hide_quantity.ToString());


            HttpPostedFileBase file;
            byte[] bytes;
            for (int i = 0; i < fileCount; i++)
            {
                file = files[i];
                bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, file.ContentLength);
                postParameters.Add("file" + i.ToString(), new KDTUtil.FileParameter(bytes, file.FileName, "image/unknown"));

            }
            string result = kit.post(MethodNameModel.KDT_ITEM_ADD, param, postParameters, "images[]");
            JObject o = JObject.Parse(result);
            var err = o["error_response"];
            if (err != null)
            {
                return (string)err["msg"];
            }
            return "添加成功";

        }
    }
}