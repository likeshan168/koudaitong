using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    /// <summary>
    /// 获取交易的请求参数类
    /// </summary>
    public class TradeRequest
    {
        /// <summary>
        /// 需要返回的交易对象字段，如tid,title,receiver_city等
        /// </summary>
        public string fields { get; set; }
        /// <summary>
        /// 交易状态，默认查询所有交易状态的数据，除了默认值外每次只能查询一种状态。
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 交易创建开始时间
        /// </summary>
        public string start_created { get; set; }
        /// <summary>
        /// 交易创建结束时间
        /// </summary>
        public string end_created { get; set; }
        /// <summary>
        /// 交易状态更新的开始时间
        /// </summary>
        public string start_update { get; set; }
        /// <summary>
        /// 交易状态更新的结束时间
        /// </summary>
        public string end_update { get; set; }
        /// <summary>
        /// 买家付款开始时间
        /// </summary>
        public string start_pay { get; set; }
        /// <summary>
        /// 买家付款结束时间
        /// </summary>
        public string end_pay { get; set; }

        /// <summary>
        /// 微信粉丝ID
        /// </summary>
        public string weixin_user_id { get; set; }

        /// <summary>
        /// 买家昵称
        /// </summary>
        public string buyer_nick { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int page_no { get; set; }
        /// <summary>
        /// 每页条数(默认40)
        /// </summary>
        public int page_size { get; set; }

    }
}