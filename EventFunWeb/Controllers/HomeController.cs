using NewIDMethod.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class HomeController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        
        // GET: Home
        public ActionResult HomeIndex()//網站的首頁
        {
            if (Session["Member"] != null)
            {
                return View("HomeIndex", "_Layout");
            }

            if (Session["Company"] != null)
                return View("HomeIndex", "_Layout");
            return View("HomeIndex", "_Layout");
        }
        public ActionResult _ADListPartial()//顯示在首頁的廣告牆
        {
            var ad = from d in db.t廣告
                     orderby d.f廣告編號 descending
                     select d;
            return PartialView("_ADListPartial", ad);
        }
        [ChildActionOnly]
        public ActionResult _EventLatestPartial()//顯示在首頁的最新活動
        {
            var tEvent = (from a in db.t活動
                          orderby a.f活動編號 descending
                          select a).Take(6);
            return PartialView("_EventLatestPartial", tEvent);
        }
        //還須新增搜尋的Partial(搜尋 人氣主題 及人氣活動)
        [HttpPost]
        public JsonResult CityChange(string CityID)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();


            if (!string.IsNullOrWhiteSpace(CityID))
            {
                var city = from d in db.t地區
                             where d.f城市編號 == CityID
                             select d;

                foreach (var district in city)
                {
                    items.Add(new KeyValuePair<string, string>(

                        district.f地區郵遞區號.ToString(),
                        district.f地區名稱.ToString()));
                }

            }
            return this.Json(items);
        }
    }
}