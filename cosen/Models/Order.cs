using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cosen.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 商品数字编号
        /// </summary>
        public string num_iid { get; set; }
        /// <summary>
        /// Sku的ID
        /// </summary>
        public string sku_id { get; set; }
        /// <summary>
        /// 商品购买数量
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 商家编码（商家为Sku设置的外部编号）
        /// </summary>
        public string outer_sku_id { get; set; }
        /// <summary>
        /// 商品货号（商家为商品设置的外部编号）
        /// </summary>
        public string outer_item_id { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 卖家昵称
        /// </summary>
        public string seller_nick { get; set; }
        /// <summary>
        /// 商品价格。精确到2位小数；单位：元
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 应付金额（商品价格乘以数量的总金额）
        /// </summary>
        public decimal total_fee { get; set; }
        /// <summary>
        /// 子订单级订单优惠金额。精确到2位小数，单位：元
        /// </summary>
        public decimal discount_fee { get; set; }
        /// <summary>
        /// 实付金额。精确到2位小数，单位：元
        /// </summary>
        public decimal payment { get; set; }
        /// <summary>
        /// SKU的值，即：商品的规格。如：机身颜色:黑色;手机套餐:官方标配
        /// </summary>

        public string sku_properties_name { get; set; }
        /// <summary>
        /// 商品主图片地址
        /// </summary>
        public string pic_path { get; set; }
        /// <summary>
        /// 商品主图片缩略图地址
        /// </summary>
        public string pic_thumb_path { get; set; }
        /// <summary>
        /// 子订单中的买家留言列表
        /// </summary>
        public BuyerMessage[] buyer_messages { get; set; }


    
    }
}
