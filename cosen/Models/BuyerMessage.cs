using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cosen.Models
{
    /// <summary>
    /// 留言信息
    /// </summary>
    public class BuyerMessage
    {
        /// <summary>
        /// 留言的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 留言的内容
        /// </summary>
        public string content { get; set; }
    }
}
