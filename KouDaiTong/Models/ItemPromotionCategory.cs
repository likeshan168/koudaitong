using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KouDaiTong.Models
{
    /// <summary>
    /// 商品推广
    /// </summary>
    public class ItemPromotionCategory
    {
        /// <summary>
        /// 商品推广栏目的ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品推广栏目的名称
        /// </summary>
        public string name { get; set; }
    }

    public class ItemPromotionCategoryResponse
    {
        public ItemPromotionCategory[] categories { get; set; }
    }

    public class ItemPromotionCategoryResult
    {
        public ItemPromotionCategoryResponse response { get; set; }
    }
}