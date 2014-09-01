using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KouDaiTong.Models
{
    /// <summary>
    /// 商品
    /// </summary>
    public class ProductItem
    {
        /// <summary>
        /// 商品分类的叶子类目id
        /// </summary>
        [Display(Name = "商品分类")]
        public int cid { get; set; }
        /// <summary>
        /// 商品推广栏目id
        /// </summary>
        [Display(Name = "商品推广栏目")]
        public int promotion_cid { get; set; }
        /// <summary>
        /// 商品标签id串 结构如：1234,1342,...，
        /// </summary>
        [Display(Name = "商品标签")]
        public string tag_ids { get; set; }
        /// <summary>
        /// 商品价格。取值范围：0.01-100000000；精确到2位小数；单位：元。需要在Sku价格所决定的的区间内
        /// </summary>
        [Display(Name = "商品价格")]
        [Required(ErrorMessage="商品价格是必须的")]
        [Range(0.01, 100000000, ErrorMessage = "取值范围：0.01-100000000")]
        public double price { get; set; }
        /// <summary>
        /// 商品标题。不能超过100字，受违禁词控制
        /// </summary>
        [Display(Name = "商品标题")]
        [Required(ErrorMessage="商品标题是必须的")]
        [MaxLength(100,ErrorMessage="不能超过100个字")]
        public string title { get; set; }
        /// <summary>
        /// 商品描述。字数要大于5个字符，小于25000个字符 ，受违禁词控制
        /// </summary>
        [Display(Name="商品描述")]
        [Required(ErrorMessage="商品描述是必须的")]
        [MinLength(5, ErrorMessage = "字数不能小于5")]
        [MaxLength(25000, ErrorMessage = "字数不能超过25000")]
        public string desc { get; set; }
        /// <summary>
        /// 是否是虚拟商品。0为否，1为是。目前不支持虚拟商品
        /// </summary>
        [Display(Name = "是否是虚拟商品")]
        [Required(ErrorMessage="该选项是必须的")]
        public int is_virtual { get; set; }
        /// <summary>
        /// 商品图片文件列表，可一次上传多张。最大支持 1M，支持的文件类型:gif,jpg,jpeg,png 

        ///注：图片参数不参与通讯协议签名，参数名中的中括号"[]"必须有，否则不能正常工作
        /// </summary>
        //[Display(Name = "商品图片文件列表")]
        //[Required(ErrorMessage="商品图片必须的")]
        //public byte[] images { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        [Display(Name = "运费")]
        [Required(ErrorMessage="运费必须的")]
        [Range(0.00, 999.00, ErrorMessage = "取值范围：0.00-999.00")]
        public double post_fee { get; set; }
        /// <summary>
        /// Sku的属性串
        /// </summary>
        [Display(Name = "Sku的属性")]
        [Required(ErrorMessage="必须的")]
        public string sku_properties { get; set; }
        /// <summary>
        /// Sku的数量串
        /// </summary>
        [Display(Name = "Sku的数量串")]
        [Required(ErrorMessage = "必须的")]
        public string sku_quantities { get; set; }
        /// <summary>
        /// Sku的价格串
        /// </summary>
        [Display(Name = "Sku的价格串")]
        [Required(ErrorMessage = "必须的")]
        public string sku_prices { get; set; }
        /// <summary>
        /// Sku的商家编码(款式+颜色)
        /// </summary>
        [Display(Name = "Sku的商家编码")]
        [Required(ErrorMessage = "必须的")]
        public string sku_outer_ids { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [Display(Name = "原价")]
        public string origin_price { get; set; }
        /// <summary>
        /// 该商品的外部购买地址
        /// </summary>
        [Display(Name = "该商品的外部购买地址")]
        public string buy_url { get; set; }

        /// <summary>
        /// 商品货号
        /// </summary>
        [Display(Name = "商品货号")]
        public string outer_id { get; set; }

        /// <summary>
        /// 每人限购多少件
        /// </summary>
        [Display(Name = "每人限购多少件")]
        public int buy_quota { get; set; }

        /// <summary>
        /// 商品总库存
        /// </summary>
        [Display(Name = "商品总库存")]
        public int quantity { get; set; }

        /// <summary>
        /// 是否隐藏商品库存
        /// </summary>
        [Display(Name = "是否隐藏商品库存")]
        public int hide_quantity { get; set; }

        /// <summary>
        /// 需要返回的商品对象字段
        /// </summary>
        [Display(Name = "需要返回的商品对象字段")]
        public string fields { get; set; }
    }
}