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
    public class CompanyMgtController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: CompanyMgt
        public ActionResult CompanyIndex()
        {
            if (Session["Company"] == null)
                return RedirectToAction("Login", "Login");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;

            var company = (from m in db.t企業會員
                           where m.f企業編號 == str_企業編號
                           select m).FirstOrDefault();

            return View(company);
        }
        public ActionResult _CompanyIndexPartial()
        {
            if (Session["Company"] == null)
                return RedirectToAction("Login", "Login");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;

            var company = (from m in db.t企業會員
                           where m.f企業編號 == str_企業編號
                           select m).FirstOrDefault();
            ViewBag.CompanyIndex = "active";

            return PartialView("_CompanyIndexPartial", company);
        }
        public ActionResult _CompanyEditPartial()
        {
            if (Session["Company"] == null)
                return RedirectToAction("Login", "Login");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            var company = (from m in db.t企業會員
                           where m.f企業編號 == str_企業編號
                           select m).FirstOrDefault();
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", company.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", company.f城市編號);
            return PartialView("_CompanyEditPartial", company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _CompanyEditSavePartial(t企業會員 t企業會員)
        {
            if (t企業會員.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/company/"), t企業會員.f企業編號 + ".jpg");
                t企業會員.photo.SaveAs(pathPhoto);
                t企業會員.f企業照片 = t企業會員.f企業編號 + ".jpg";
            }
            if (ModelState.IsValid)
            {
                db.Entry(t企業會員).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CompanyIndex");
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", t企業會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t企業會員.f城市編號);
            return View(t企業會員);
        }
        public ActionResult _ADMgtPartial()
        {
            if (Session["Company"] == null)
                return RedirectToAction("CreatMember", "MemberHome");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            var AD = from ad in db.t廣告
                        where ad.f企業編號 == str_企業編號
                        select ad;
            return PartialView("_ADMgtPartial", AD);
        }
        public ActionResult ADList()
        {
            if (Session["Company"] == null)
                return RedirectToAction("HomeIndex", "Home");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            var AD = from ad in db.t廣告
                     where ad.f企業編號 == str_企業編號
                     select ad;
            return View(AD);
        }
        public ActionResult ADNew()
        {
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            return View();
        }
        [HttpPost]
        public ActionResult ADNew(t廣告 ad)
        {
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            ad.f企業編號 = str_企業編號;
            ad.f廣告編號 = methodNewID.new廣告編號();
            if (ad.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/AD/"), ad.f企業編號 + ad.f廣告編號 + ".jpg");//存進去的資料夾
                ad.photo.SaveAs(pathPhoto);//將檔案存取
                ad.f廣告圖片 = ad.f企業編號 + ad.f廣告編號 + ".jpg";
            }

            ad.f廣告上下架 = false;
            //要加做廣告上下架 預設都是下架

            db.t廣告.Add(ad);
            db.SaveChanges();

            return RedirectToAction("ADList");
        }
        public ActionResult ADDelete(int fId)
        {

            var table = (from p in db.t廣告
                         where p.f廣告編號 == fId
                         select p).FirstOrDefault();
            db.t廣告.Remove(table);
            db.SaveChanges();
            return RedirectToAction("ADList");
        }
        public ActionResult ADEdit(int fId)
        {
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            var table = (from p in db.t廣告
                         where p.f廣告編號 == fId
                         select p).FirstOrDefault();

            return View(table);
        }
        [HttpPost]
        public ActionResult ADEdit(t廣告 ad)
        {

            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            ViewBag.id = str_企業編號;
            if (ad.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/AD/"), ad.f企業編號 + ad.f廣告編號 + ".jpg");//存進去的資料夾
                ad.photo.SaveAs(pathPhoto);//將檔案存取
                ad.f廣告圖片 = ad.f企業編號 + ad.f廣告編號 + ".jpg";
            }

            db.Entry(ad).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ADList");
        }
    }
}