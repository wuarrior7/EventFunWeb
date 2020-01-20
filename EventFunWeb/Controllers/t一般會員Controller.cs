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
    public class t一般會員Controller : Controller
    {
        private dbEventFunEntities db = new dbEventFunEntities();

        // GET: t一般會員
        public ActionResult Index()
        {
            var t一般會員 = db.t一般會員.Include(t => t.t地區).Include(t => t.t城市);
            return View(t一般會員.ToList());
        }

        // GET: t一般會員/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t一般會員 t一般會員 = db.t一般會員.Find(id);
            if (t一般會員 == null)
            {
                return HttpNotFound();
            }
            return View(t一般會員);
        }

        // GET: t一般會員/Create
        public ActionResult Create()
        {
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號");
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱");
            return View();
        }

        // POST: t一般會員/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "f會員編號,f會員帳號,f會員密碼,f會員信箱,f會員名稱,f會員性別,f出生年月日,f會員簡介,f會員行動電話,f城市編號,f郵遞區號,f地址,f會員照片,f帳號狀態,f上次登入時間,f創建時間")] t一般會員 t一般會員)
        {
            if (ModelState.IsValid)
            {
                db.t一般會員.Add(t一般會員);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t一般會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t一般會員.f城市編號);
            return View(t一般會員);
        }

        // GET: t一般會員/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t一般會員 t一般會員 = db.t一般會員.Find(id);
            if (t一般會員 == null)
            {
                return HttpNotFound();
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t一般會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t一般會員.f城市編號);
            return View(t一般會員);
        }

        // POST: t一般會員/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "f會員編號,f會員帳號,f會員密碼,f會員信箱,f會員名稱,f會員性別,f出生年月日,f會員簡介,f會員行動電話,f城市編號,f郵遞區號,f地址,f會員照片,f帳號狀態,f上次登入時間,f創建時間")] t一般會員 t一般會員)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t一般會員).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.f郵遞區號 = new SelectList(db.t地區, "f地區郵遞區號", "f城市編號", t一般會員.f郵遞區號);
            ViewBag.f城市編號 = new SelectList(db.t城市, "f城市編號", "f城市名稱", t一般會員.f城市編號);
            return View(t一般會員);
        }

        // GET: t一般會員/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t一般會員 t一般會員 = db.t一般會員.Find(id);
            if (t一般會員 == null)
            {
                return HttpNotFound();
            }
            return View(t一般會員);
        }

        // POST: t一般會員/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            t一般會員 t一般會員 = db.t一般會員.Find(id);
            db.t一般會員.Remove(t一般會員);
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
