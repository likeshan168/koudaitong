using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin
{
    public class HomeModule:NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                var model = new {title="We've got issues" };
                return View["Home", model];
            };
        }
    }
}