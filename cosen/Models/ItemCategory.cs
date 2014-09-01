using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cosen.Models
{
    /// <summary>
    /// 商品分类数据结构
    /// </summary>
    public class ItemCategory
    {
        /// <summary>
        /// 商品分类的ID
        /// </summary>
        public int cid { get; set; }
        /// <summary>
        /// 父分类ID，等于0时，代表的是一级的分类
        /// </summary>
        public int parent_cid { get; set; }
        /// <summary>
        /// 商品分类的名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 该分类是否为父分类(即：该分类是否还有子分类)
        /// </summary>
        public bool is_parent { get; set; }
        /// <summary>
        /// 子分类列表。如果is_parent为false，则该字段为空
        /// </summary>
        public ItemCategory[] sub_categories { get; set; }
    }

    public class ItemCategoryResponse
    {
        public ItemCategory[] categories { get; set; }
    }

    public class ItemCategoryResult
    {
        public ItemCategoryResponse response { get; set; }
    }
}
