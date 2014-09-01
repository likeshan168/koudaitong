using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cosen.Models
{
    public class CategoriesAndTags
    {
        /// <summary>
        /// 商品分类
        /// </summary>
        public ItemCategory[] ItemCategories { get; set; }

        /// <summary>
        /// 商品推广
        /// </summary>
        public ItemPromotionCategory[] ItemPromotionCategories { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public ItemTag[] ItemTags { get; set; }

        /// <summary>
        /// 商品详细
        /// </summary>
        //public IList<kdt_style_detail_procResult> Details { get; set; }
    }

    public class DetalsAndCategories
    {
        public CategoriesAndTags CTs { get; set; }

        public IList<kdt_style_detail_procResult> Details { get; set; }
    }
}