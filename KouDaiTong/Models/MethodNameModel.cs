using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KouDaiTong.Models
{
    public class MethodNameModel
    {
        /// <summary>
        /// 获取商品分类二维列表 方法名称
        /// </summary>
        public static string GET_ITEM_CATEGORIES="kdt.itemcategories.get";
        /// <summary>
        /// 获取商品推广栏目列表
        /// </summary>
        public static string GET_ITEM_CATEGORIES_PROMOTIONS="kdt.itemcategories.promotions.get";
        /// <summary>
        /// 获取商品自定义标签列表
        /// </summary>
        public static string GET_ITEM_CATEGORIES_TAGS = "kdt.itemcategories.tags.get";//kdt.itemcategories.tags.get

        /// <summary>
        /// 新增一个商品的方法名称
        /// </summary>
        public static string KDT_ITEM_ADD = "kdt.item.add";
    }
}