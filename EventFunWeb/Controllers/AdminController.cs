using EventFunSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class AdminController : Controller
    {
        //管理員首頁
        public ActionResult AdminIndex()
        {
            return View();
        }
        //管理員個人資料
        public ActionResult _AdminIndexPartial()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            if (Session[CDictionary.Manager] == null)
                return RedirectToAction("Login");
            int managerID = (Session[CDictionary.Manager] as t管理者資料表).f管理者編號;

            var manager = (from m in db.t管理者資料表
                           where m.f管理者編號 == managerID
                           select m).FirstOrDefault();

            return PartialView("_AdminIndexPartial", manager);
        }
        //管理員個人編輯畫面
        public ActionResult _AdminEditPartial()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            var adminid = (Session[CDictionary.Manager] as t管理者資料表).f管理者編號;
            var t = (from ad in db.t管理者資料表
                     where ad.f管理者編號 == adminid
                     select ad).FirstOrDefault();
            return PartialView("_AdminEditPartial", t);
        }
        //管理員個人編輯畫面儲存
        [HttpPost]
        public ActionResult _AdminSavePartial(t管理者資料表 ad)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            //判斷是否有圖片
            if (ad.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/admin/"), ad.f管理者編號 + ".jpg");
                ad.photo.SaveAs(pathPhoto);
            }
            if (ModelState.IsValid)
            {

                ad.f個人照片 = ad.f管理者編號.ToString() + ".jpg";
                ad.f上次登入時間 = DateTime.Now;
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return RedirectToAction("AdminIndex");
        }

    }
}