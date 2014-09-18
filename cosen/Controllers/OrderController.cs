using cosen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cosen.Controllers
{
    /// <summary>
    /// 订单管理
    /// </summary>
    public class OrderController : Controller
    {
        [Ninject.Inject]
        private LogicModel logic { get; set; }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string searchT, string startDate, string endDate, string nickName, string status)
        {
            return Json(logic.GetTradeOrders(searchT, startDate, endDate, nickName, status));
        }
    }
}
