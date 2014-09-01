using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KouDaiTong.Models
{
    public class CategoriesAndTags
    {
        /// <summary>
        /// 商品分类
        /// </summary>
        public IList<ItemCategory> ItemCategories { get; set; }

        /// <summary>
        /// 商品推广
        /// </summary>
        public IList<ItemPromotionCategory> ItemPromotionCategories { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public IList<ItemTag> ItemTags { get; set; }
    }
}