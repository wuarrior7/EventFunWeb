using NewIDMethod.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventFunWeb.Controllers
{
    public class AddEventController : Controller
    {
        private dbEventFunEntities db = new dbEventFunEntities();
        //新增活動
        public ActionResult CreateEvent()
        {
            if (Session["Company"] == null)
                return RedirectToAction("CreatMember", "MemberHome");

            SelectList selectList = new SelectList(db.t主題類型.ToList(), "f主題編號", "f主題名稱");
            ViewBag.SelectList = selectList;

           // ViewBag.f主題名稱 = new SelectList(db.t主題類型, "f主題編號","f主題名稱");
          
            ViewBag.f次主題名稱 = new SelectList(db.t次主題類型, "f次主題編號", "f次主題名稱");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateEvent([Bind(Include = "f次主題編號,f企業編號,f活動聯絡人,f聯絡人電話,f聯絡人信箱,f活動名稱,f活動網址,f活動簡介,f活動內容,f人氣")] t活動 t活動)
        {
            if (Session["Company"] == null)
                return RedirectToAction("CreatMember", "MemberHome");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
            if (ModelState.IsValid)
            {
                t活動.f活動編號 = methodNewID.new活動編號();
                t活動.f企業編號 = str_企業編號;
                db.t活動.Add(t活動);
                db.SaveChanges();
                Session["Event"] = t活動.f活動名稱;
                Session["EventID"] = t活動.f活動編號;
                return RedirectToAction("CreateImages");
            }

            ViewBag.f企業編號 = new SelectList(db.t企業會員, "f企業編號", "f企業名稱", t活動.f企業編號);
            ViewBag.f次主題編號 = new SelectList(db.t次主題類型, "f次主題編號", "f次主題名稱", t活動.f次主題編號);

            return View();
        }
        [HttpPost]
        public JsonResult Themes(string themeID)
        {
           List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();


            if (!string.IsNullOrWhiteSpace(themeID))
            {
               var themes = from p in db.t次主題類型
                                    where p.f主題編號 == themeID
                                    select p;

                foreach (var theme in themes)
                    {
                        items.Add(new KeyValuePair<string, string>(
                            
                            theme.f次主題編號.ToString(),
                            theme.f次主題名稱.ToString()));
                    }
               
            }
            return this.Json(items);
        }

        private IEnumerable<dbEventFunEntities> GetThemes(string themeID)
        {
            throw new NotImplementedException();
        }



        //活動圖片/Create
        public ActionResult CreateImages()
        {
            ViewBag.f活動編號 = new SelectList(db.t活動, "f活動編號", "f活動名稱");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateImages(t活動圖片 t活動圖片)
        {//[Bind(Include = "f圖片編號,f活動編號,f活動圖片")] 
            if (ModelState.IsValid )
            {
               string fileName = Path.GetFileName(t活動圖片.photo.FileName);
               // string fileName = methodNewID.new活動圖片編號().ToString();
                var pathPhoto = Path.Combine(Server.MapPath("~/Content/images/activity"), t活動圖片.f活動編號+ ".jpg");

                t活動圖片.photo.SaveAs(pathPhoto);
                t活動圖片.f圖片編號 = methodNewID.new活動圖片編號();

                dbEventFunEntities db = new dbEventFunEntities();
                t活動圖片.f活動圖片 = "/Content/images/activity/" + t活動圖片.f活動編號+".jpg";

                db.t活動圖片.Add(t活動圖片);
                db.SaveChanges();
                return RedirectToAction("AddEventOK");
            }

            ViewBag.f活動編號 = new SelectList(db.t活動, "f活動編號", "f次主題編號", t活動圖片.f活動編號);
            return View("CreateImages");
        }  
        
        // GET: t活動/Edit/5
    public ActionResult EditEvent(string id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        t活動 t活動 = db.t活動.Find(id);
        if (t活動 == null)
        {
            return HttpNotFound();
        }
        ViewBag.f企業編號 = new SelectList(db.t企業會員, "f企業編號", "f統一編號", t活動.f企業編號);
        ViewBag.f次主題編號 = new SelectList(db.t次主題類型, "f次主題編號", "f次主題名稱", t活動.f次主題編號);
        return View(t活動);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult EditEvent([Bind(Include = "f活動編號,f次主題編號,f企業編號,f活動聯絡人,f聯絡人電話,f聯絡人信箱,f活動名稱,f活動網址,f活動簡介,f活動內容,f人氣")] t活動 t活動)
    {
         if (Session["Company"] == null)
                return RedirectToAction("CreatMember", "MemberHome");
         string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;
        if (ModelState.IsValid)
        {
            
            db.Entry(t活動).State = EntityState.Modified;
            db.SaveChanges();
            Session["Event"] = t活動.f活動名稱;
            Session["EventID"] = t活動.f活動編號;
            return RedirectToAction("CreateImages");
        }
        ViewBag.f企業編號 = new SelectList(db.t企業會員, "f企業編號", "f統一編號", t活動.f企業編號);
        ViewBag.f次主題編號 = new SelectList(db.t次主題類型, "f次主題編號", "f次主題名稱", t活動.f次主題編號);
        return View(t活動);
    }
   

    public ActionResult AddEventOK()
    {
        return View();
    }
    public ActionResult CompanyEventList ()
    {
            if (Session["Company"] == null)
                return RedirectToAction("Login", "Login");
            string str_企業編號 = (Session["Company"] as t企業會員).f企業編號;

            var t活動 = (from p in db.t活動
                       where p.f企業編號 == str_企業編號
                       select p);
            return View(t活動.ToList());
     }
    public ActionResult EditEventHome (string id)
     {
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
} }