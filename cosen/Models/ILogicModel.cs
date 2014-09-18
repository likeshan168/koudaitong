using System;
namespace cosen.Models
{
    interface ILogicModel
    {
        DetalsAndCategories GetDetails(string styleNo, System.Web.Caching.Cache cache);
        ItemCategory[] GetItemCategories(System.Web.Caching.Cache cache);
        ItemTag[] GetItemCategoryTags();
        ItemPromotionCategory[] GetItemPromotionCategories();
        Search_Result_Info GetProductInfos(string searchT, string searchV, int page, out int total);
        ItemCategory[] GetSubItemCategories(int pcid, System.Web.Caching.Cache cache);
        string GetTradeOrders(string searchT, string startDate, string endDate, string nickName, string status);
        CategoriesAndTags HeBing(System.Web.Caching.Cache cache);
        string PostProductItem(ProductItem item, System.Web.HttpFileCollectionBase files);
    }
}
