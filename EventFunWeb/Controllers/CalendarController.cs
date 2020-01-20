using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class CalendarController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _CalendarPartial()
        {
            return PartialView("_CalendarPartial");
        }
        public ActionResult _CalendarFavoriteEvent()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var FavoriteEvent = (from fe in db.t會員喜愛活動
                                 where fe.f會員編號 == str_會員編號
                                 select fe.f活動編號);

            List<t活動場次> tt = new List<t活動場次>();
            foreach (string str_活動編號 in FavoriteEvent)
            {
                var Date_活動場次s = from de in db.t活動場次
                                where de.t活動日期.t活動.f活動編號 == str_活動編號
                                select de;
                
                foreach (var Date場次 in Date_活動場次s)
                {
                    tt.Add(Date場次);
                }
            }
            return PartialView("_CalendarFavoriteEvent",tt);
        }
        public ActionResult _CalendarShoppingCartEventPartial()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var shoppingCartEvent = from sc in db.t票券購物車
                                    where sc.f會員編號 == str_會員編號
                                    select sc.t活動票券.t活動場次;

            return PartialView("_CalendarShoppingCartEventPartial", shoppingCartEvent);
        }
        public ActionResult _CalendarOrderEventPartial()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var orderEvent = from oe in db.t票券訂單明細
                             where oe.t票券訂單.f會員編號 == str_會員編號
                             select oe.t活動票券.t活動場次;
            return PartialView("_CalendarOrderEventPartial", orderEvent);
        }
        public ActionResult _FavoriteEventToCalendarPartial()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var FavoriteEvent = (from fe in db.t會員喜愛活動
                                 where fe.f會員編號 == str_會員編號
                                 select fe.f活動編號);

            List<t活動場次> tt = new List<t活動場次>();
            foreach (string str_活動編號 in FavoriteEvent)
            {
                var Date_活動場次s = from de in db.t活動場次
                                 where de.t活動日期.t活動.f活動編號 == str_活動編號
                                 select de;

                foreach (var Date場次 in Date_活動場次s)
                {
                    tt.Add(Date場次);
                }
            }
            return PartialView("_FavoriteEventToCalendarPartial", tt);
        }
        public ActionResult _ShoppingCartEventToCalendarPartial()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var shoppingCartEvent = from sc in db.t票券購物車
                                    where sc.f會員編號 == str_會員編號
                                    select sc.t活動票券.t活動場次;

            return PartialView("_ShoppingCartEventToCalendarPartial", shoppingCartEvent);
        }
        public ActionResult _OrderEventToCalendarPartial()
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var orderEvent = from oe in db.t票券訂單明細
                             where oe.t票券訂單.f會員編號 == str_會員編號
                             select oe.t活動票券.t活動場次;
            return PartialView("_OrderEventToCalendarPartial", orderEvent);
        }
    }
}