using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class gMemberDataController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: gMemberData
        public ActionResult gMemberIndex()
        {
            return View();
        }
        public ActionResult _gMemberIndex()
        {
            if (Session["Member"] == null)
                return RedirectToAction("CreatMember", "MemberHome");//傳去登入頁面
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;

            var member = (from m in db.t一般會員
                          where m.f會員編號 == str_會員編號
                          select m).FirstOrDefault();

            return View(member);
        }
        public ActionResult _gMemberEdit()
        {
            if (Session["Member"] == null)
                return RedirectToAction("CreatMember", "MemberHome");//傳去登入頁面
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            var member = (from m in db.t一般會員
                          where m.f會員編號 == str_會員編號
                          select m).FirstOrDefault();
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", member.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", member.f城市編號);
            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _gMemberEdit(t一般會員 tMember)
        {
            if (tMember.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/member/"), tMember.f會員編號 + ".jpg");
                tMember.photo.SaveAs(pathPhoto);
                tMember.f會員照片 = tMember.f會員編號 + ".jpg";
            }
            if (tMember != null)
            {
                db.Entry(tMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("gMemberIndex");
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", tMember.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", tMember.f城市編號);
            return View(tMember);
        }
        public ActionResult gMemberEdit(string fId)
        {
            if (Session["Member"] == null)
                return RedirectToAction("CreatMember", "MemberHome");//傳去登入頁面
            var member = (from m in db.t一般會員
                           where m.f會員編號 == fId
                           select m).FirstOrDefault();
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", member.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", member.f城市編號);
            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult gMemberEdit(t一般會員 tMember)
        {
            if (tMember.photo != null)
            {
                var pathPhoto = Path.Combine(Server.MapPath("/Content/images/member/"), tMember.f會員編號 + ".jpg");
                tMember.photo.SaveAs(pathPhoto);
                tMember.f會員照片 = tMember.f會員編號 + ".jpg";
            }
            if (tMember!=null)
            {
                db.Entry(tMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("gMemberIndex");
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f地區名稱", tMember.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", tMember.f城市編號);
            return View(tMember);
        }
    }
}