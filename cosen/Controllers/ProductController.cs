using cosen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cosen.Controllers
{
    //[CustomRequireHttps]
    public class ProductController : Controller
    {
        LogicModel logic = null;
        // GET: Product
        public ActionResult Index()
        {
            int total = 0;
            logic = new LogicModel();
            var q = logic.GetProductInfos("4", string.Empty, 1, out total);
            if (total < 10 && total > 0)
            {
                total = 1;
            }
            else if (total > 10)
            {
                int zc = total / 10;
                int cy = total % 10;
                total = zc + (cy > 0 ? 1 : 0);
            }
            else
            {
                total = 0;
            }
            ViewData["searchT"] = "4";
            ViewData["searchV"] = string.Empty;
            ViewData["total"] = total;
            return View(q);
        }
        [HttpPost]
        public ActionResult Index(string searchT, string searchV)
        {
            int total = 0;
            logic = new LogicModel();
            var q = logic.GetProductInfos(searchT, searchV, 1, out total);
            if (total < 10 && total > 0)
            {
                total = 1;
            }
            else if (total > 10)
            {
                int zc = total / 10;
                int cy = total % 10;
                total = zc + (cy > 0 ? 1 : 0);
            }
            else
            {
                total = 0;
            }

            ViewData["total"] = total;
            ViewData["searchT"] = searchT;
            ViewData["searchV"] = searchV;
            return View(q);
        }

        public JsonResult Search(string searchT, string searchV, int page)
        {
            int total = 0;
            logic = new LogicModel();
            return Json(logic.GetProductInfos(searchT, searchV, page, out total));
        }
        /// <summary>
        /// 测试用的
        /// </summary>
        /// <returns></returns>
        public ActionResult GetItemCategory()
        {
            logic = new LogicModel();
            return PartialView(logic.GetItemCategories(HttpContext.Cache));
        }
        /// <summary>
        /// 合并商品分类，推广和标签
        /// </summary>
        /// <returns></returns>
        //[ChildActionOnly]
        //public ActionResult Category()
        //{
        //    logic = new LogicModel();
        //    return PartialView("_PartialCategory", logic.HeBing());
        //}
        /// <summary>
        /// 获取商品子类
        /// </summary>
        /// <param name="cid">类别id</param>
        /// <returns></returns>
        public JsonResult GetSub(int pcid)
        {
            logic = new LogicModel();
            return Json(logic.GetSubItemCategories(pcid,HttpContext.Cache));
        }
        /// <summary>
        /// 明细
        /// </summary>
        /// <param name="styleNO">款式</param>
        /// <returns></returns>
        public ActionResult Details(string styleNO)
        {
            logic = new LogicModel();
           return View(logic.GetDetails(styleNO,HttpContext.Cache));
            
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult UploadProductItems(ProductItem item)
        {
            logic = new LogicModel();
            return Content(logic.PostProductItem(item, Request.Files));
        }

    }
}