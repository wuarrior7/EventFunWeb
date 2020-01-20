using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventFunWeb;

namespace EventFunWeb.Controllers
{
    public class EventController : Controller
    {
        private dbEventFunEntities db = new dbEventFunEntities();

        // GET: Event
        public ActionResult EventList()
        {
            var tEvent = from a in db.t活動
                        select a;
            return View(tEvent);
        }
       
        public ActionResult EventDetails(string id)
        {
          // ViewBag.img = "../images/activity/" + id + ".jpg";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            t活動 t活動 = db.t活動.Find(id);
            if (t活動 == null)
            {
                return HttpNotFound();
            }
            return View(t活動);
        }
       


    }
}
