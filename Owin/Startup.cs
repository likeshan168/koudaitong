using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}