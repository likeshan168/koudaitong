using KouDaiTong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KouDaiTong.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View(new LogicModel().GetItemCategories());
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public JsonResult GetSub(int cid)
        {
            return Json(new LogicModel().GetSubItemCategories(cid));
        }

        public ActionResult TuiGuang()
        {
            return View(new LogicModel().GetItemPromotionCategories());
        }

        public ActionResult BiaoQian()
        {
            return View(new LogicModel().GetItemCategoryTags());
        }
    }
}