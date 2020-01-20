using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class ADController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: AD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _ADListVerticalPartial()
        {
            var ad = from d in db.t廣告
                     orderby d.f廣告編號 descending
                     select d;
            return PartialView("_ADListVerticalPartial", ad);
        }
    }
}