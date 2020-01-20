using EventFunSystem.Models;
using NewIDMethod.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class LoginController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: Login
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        public ActionResult CreatMember()
        {
            //Session["Member"] = null;
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號");
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatMember([Bind(Include = "f會員帳號,f會員密碼,f會員信箱,f會員名稱,f會員性別,f出生年月日,f會員簡介,f會員行動電話,f城市編號,f郵遞區號,f地址,f會員照片,f帳號狀態,f上次登入時間,f創建時間")] t一般會員 tGmember)
        {
            if (ModelState.IsValid)
            {
                tGmember.f會員編號 = methodNewID.new一般會員編號();
                tGmember.f創建時間 = DateTime.Now;
                tGmember.f帳號狀態 = true;
                db.t一般會員.Add(tGmember);
                db.SaveChanges();
                //Session["CreatMember"] = tGmember.f會員名稱;
                ViewBag.Login = "註冊成功，請按登入使用會員功能";
                return Redirect("~/Home/HomeIndex");
            }

            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", tGmember.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", tGmember.f城市編號);
            return View(tGmember);
        }
        public ActionResult CreatCompany(t企業會員 company)
        {
            company.f企業編號 = methodNewID.new企業會員編號();
            company.f企業創建日期 = DateTime.Now;
            company.f企業帳號狀態 = true;
            db.t企業會員.Add(company);
            db.SaveChanges();
            return Redirect("~/Home/HomeIndex");
        }
        public ActionResult MemberLogin(string fmemberID, string fpwd)
        {
            var member = db.t一般會員.Where(m => m.f會員帳號 == fmemberID && m.f會員密碼 == fpwd).FirstOrDefault();
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View("Login");
            }

            Session["Member"] = member;
            return Redirect("~/Home/HomeIndex");
        }
        public ActionResult CompanyLogin(string CfmemberID, string Cfpwd)
        {
            var company = db.t企業會員.Where(m => m.f企業帳號 == CfmemberID && m.f企業密碼 == Cfpwd).FirstOrDefault();
            if (company == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View("Login");
            }

            Session["Company"] = company;
            return Redirect("~/Home/HomeIndex");
        }
        public ActionResult AdminLogin(string str_管理者帳號, string str_管理者密碼)
        {
            var manager = db.t管理者資料表.Where(m => m.f管理者帳號 == str_管理者帳號 && m.f管理者密碼 == str_管理者密碼).FirstOrDefault();
            if (manager == null)
            {
                ViewBag.Message = "帳密錯誤，你不是管理者";
                return View("Login");
            }
            manager.f上次登入時間 = DateTime.Now;
            //使用Session變數記錄登入者
            //Session[CDictionary.Manager_Welcome] = manager.f管理者名稱 + "，我們偉大的管理者~";
            //使用Session變數紀錄登入的會員物件
            Session[CDictionary.Manager] = manager;
            //前往登入後畫面
            return Redirect("~/Home/HomeIndex");
        }
    }
}