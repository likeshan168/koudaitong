using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    /// <summary>
    /// 商品标签数据结构
    /// </summary>
    public class ItemTag
    {
        /// <summary>
        /// 商品标签的ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品标签的名称
        /// </summary>
        public string name { get; set; }
    }

    public class ItemTagResponse
    {
        public ItemTag[] tags { get; set; }
    }

    public class ItemTagResult
    {
        public ItemTagResponse response { get; set; }
    }
}