using cosen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cosen.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View(new LogicModel().GetItemCategories(HttpContext.Cache));
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public JsonResult GetSub(int cid)
        {
            return Json(new LogicModel().GetSubItemCategories(cid,HttpContext.Cache));
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