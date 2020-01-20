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
    public class t企業會員Controller : Controller
    {
        private dbEventFunEntities db = new dbEventFunEntities();

        // GET: t企業會員
        public ActionResult Index()
        {
            var t企業會員 = db.t企業會員.Include(t => t.t地區).Include(t => t.t城市);
            return View(t企業會員.ToList());
        }

        // GET: t企業會員/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t企業會員 t企業會員 = db.t企業會員.Find(id);
            if (t企業會員 == null)
            {
                return HttpNotFound();
            }
            return View(t企業會員);
        }

        // GET: t企業會員/Create
        public ActionResult Create()
        {
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號");
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱");
            return View();
        }

        // POST: t企業會員/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "f企業編號,f統一編號,f企業帳號,f企業密碼,f企業名稱,f企業簡介,f企業電話,f城市編號,f郵遞區號,f企業地址,f聯絡人,f聯絡人行動電話,f企業照片,f企業信箱,f企業創建日期,f企業帳號狀態")] t企業會員 t企業會員)
        {
            if (ModelState.IsValid)
            {
                db.t企業會員.Add(t企業會員);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t企業會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t企業會員.f城市編號);
            return View(t企業會員);
        }

        // GET: t企業會員/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t企業會員 t企業會員 = db.t企業會員.Find(id);
            if (t企業會員 == null)
            {
                return HttpNotFound();
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t企業會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t企業會員.f城市編號);
            return View(t企業會員);
        }

        // POST: t企業會員/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "f企業編號,f統一編號,f企業帳號,f企業密碼,f企業名稱,f企業簡介,f企業電話,f城市編號,f郵遞區號,f企業地址,f聯絡人,f聯絡人行動電話,f企業照片,f企業信箱,f企業創建日期,f企業帳號狀態")] t企業會員 t企業會員)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t企業會員).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t企業會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t企業會員.f城市編號);
            return View(t企業會員);
        }

        // GET: t企業會員/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t企業會員 t企業會員 = db.t企業會員.Find(id);
            if (t企業會員 == null)
            {
                return HttpNotFound();
            }
            return View(t企業會員);
        }

        // POST: t企業會員/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            t企業會員 t企業會員 = db.t企業會員.Find(id);
            db.t企業會員.Remove(t企業會員);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
