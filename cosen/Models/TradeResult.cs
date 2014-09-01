using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    /// <summary>
    /// 获取交易的返回类
    /// </summary>
    public class TradeResult
    {
        /// <summary>
        /// 搜索到的交易总数
        /// </summary>
        public int total_results { get; set; }
        /// <summary>
        /// 搜索到的交易列表
        /// </summary>
        public Trade[] trades { get; set; }
    }


    public class TradeResponse
    {
        /// <summary>
        ///交易返回结果
        /// </summary>
        public TradeResult response { get; set; }
    }
    public class Trade
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        public string tid { get; set; }
        /// <summary>
        /// 商品购买数量
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品主图片地址
        /// </summary>
        public string pic_path { get; set; }
        /// <summary>
        /// 商品主图片缩略图地址
        /// </summary>
        public string pic_thumb_path { get; set; }
        /// <summary>
        /// 交易标题，以首个商品标题作为此标题的值
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 微信粉丝ID
        /// </summary>
        public string weixin_user_id { get; set; }
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string buyer_nick { get; set; }
        /// <summary>
        /// 买家购买附言
        /// </summary>
        public string buyer_message { get; set; }
        /// <summary>
        /// 卖家备注星标，取值范围 1、2、3、4、5
        /// </summary>
        public int seller_flag { get; set; }
        /// <summary>
        /// trade_memo卖家对该交易的备注
        /// </summary>
        public string trade_memo { get; set; }
        /// <summary>
        /// 收货人的所在城市
        /// </summary>
        public string receiver_city { get; set; }
        /// <summary>
        /// 收货人的所在地区
        /// </summary>
        public string receiver_district { get; set; }
        /// <summary>
        /// 收货人的姓名
        /// </summary>
        public string receiver_name { get; set; }
        /// <summary>
        /// 收货人的所在省份
        /// </summary>
        public string receiver_state { get; set; }

        /// <summary>
        /// 收货人的详细地址
        /// </summary>
        public string receiver_address { get; set; }
        /// <summary>
        /// 收货人的邮编
        /// </summary>
        public string receiver_zip { get; set; }
        /// <summary>
        /// 收货人的手机号码
        /// </summary>
        public string receiver_mobile { get; set; }

        /// <summary>
        /// 订单维权状态。
        /// 0 无维权，
        /// 1 顾客发起维权，9 商家正在处理，
        /// 2 顾客拒绝商家的处理结果，
        /// 3 顾客接受商家的处理结果
        /// </summary>
        public int feedback { get; set; }

        /// <summary>
        /// 外部交易编号。因为目前只有微信支付，所以就是指微信交易编号
        /// </summary>
        public string outer_tid { get; set; }
        /// <summary>
        /// 交易状态。可选值：
        ///TRADE_NO_CREATE_PAY(没有创建支付交易) 
        ///WAIT_BUYER_PAY(等待买家付款) 
        ///WAIT_SELLER_SEND_GOODS(等待卖家发货，即：买家已付款) 
        ///WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货，即：卖家已发货) 
        ///TRADE_BUYER_SIGNED(买家已签收)
        ///TRADE_CLOSED(付款以后用户退款成功，交易自动关闭) 
        ///TRADE_CLOSED_BY_USER(付款以前，卖家或买家主动关闭交易)
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 创建交易时的物流方式。
        /// 可选值：express（快递），
        /// fetch（到店自提）
        /// </summary>
        public string shipping_type { get; set; }

        /// <summary>
        /// 运费。单位：元，精确到分
        /// </summary>
        public decimal post_fee { get; set; }


        /// <summary>
        /// 商品总价（商品价格乘以数量的总金额）。单位：元，精确到分
        /// </summary>
        public string total_fee { get; set; }
        /// <summary>
        /// 订单优惠金额（不包含子订单的优惠金额）。单位：元，精确到分
        /// </summary>
        public decimal discount_fee { get; set; }
        /// <summary>
        /// 实付金额。单位：元，精确到分
        /// </summary>
        public string payment { get; set; }
        /// <summary>
        /// 交易创建时间
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 买家付款时间
        /// </summary>
        public string pay_time { get; set; }
        /// <summary>
        /// 支付类型。
        /// 可选值：
        /// WEIXIN（微信支付），
        /// ALIPAY（支付宝支付），
        /// BANKCARDPAY（银行卡支付）
        /// </summary>
        public string pay_type { get; set; }

        /// <summary>
        /// 卖家发货时间
        /// </summary>
        public string consign_time { get; set; }
        /// <summary>
        /// 买家签收时间
        /// </summary>
        public string sign_time { get; set; }
        /// <summary>
        /// 买家下单的地区
        /// </summary>
        public string buyer_area { get; set; }
        /// <summary>
        /// 子订单列表
        /// </summary>
        public Order[] orders { get; set; }


    }
}