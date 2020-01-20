using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewIDMethod.Class;

namespace EventFunWeb.Controllers
{
    public class ForumController : Controller
    {
        dbEventFunEntities db = new dbEventFunEntities();
        // GET: Article
        public ActionResult _TopicPartial()
        {
            var t = (from topic in db.t主題類型
                     orderby topic.f主題優先度
                     select topic).ToList();
            return PartialView("_TopicPartial", t);
        }
        public ActionResult ForumArticleNew(string topicid)
        {
            if (Session["Member"] == null)
                return RedirectToAction("Login", "Login");
            ViewBag.topicid = topicid;
            var q = (from p in db.t主題類型
                    where p.f主題編號 == topicid
                    select p).FirstOrDefault();
            ViewBag.topicName = q.f主題名稱;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ForumArticleNew(t論壇文章資料表 article)
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            ViewBag.id = str_會員編號;
            article.f文章瀏覽數 = 0;
            article.f發布時間 = DateTime.Now;
            article.f會員編號= str_會員編號; ;
            article.f文章編號 = methodNewID.new文章編號(article.f主題編號);

            article.f最新發布時間 = article.f發布時間;
            article.f最新發表會員編號 = article.f會員編號;

            db.t論壇文章資料表.Add(article);
            db.SaveChanges();
            var q = (from p in db.t主題類型
                     where p.f主題編號 == article.f主題編號
                     select p).FirstOrDefault();

            string topic = q.f主題名稱;


            return RedirectToAction("ForumArticleList", "Forum", new { topicName = topic });
        }

        public ActionResult ForumArticleList(string topicName ="全部")
        {
            if (Session["Member"] == null)
                return RedirectToAction("Login", "Login");
            List<t論壇文章資料表> articles;
            ViewBag.topicName = topicName;
            if (topicName != "全部")
            {
                var topic = (from p in db.t主題類型
                             where p.f主題名稱 == topicName
                             select p).FirstOrDefault();

                articles = (from article in db.t論壇文章資料表
                            where article.f主題編號 == topic.f主題編號
                            orderby article.f最新發布時間 descending
                            select article).ToList();
                if (articles == null) {
                    return View();
                }
               ViewBag.topicid = topic.f主題編號;

            }
            else
            {
                articles = (from article in db.t論壇文章資料表
                            orderby article.f最新發布時間 descending
                            select article).ToList();
                ViewBag.topicid = null;
            }

            foreach (t論壇文章資料表 article in articles)
            {
                var q1 = (from t in db.t主題類型
                         where t.f主題編號 == article.f主題編號
                         select t).FirstOrDefault();
                article.主題名稱 = q1.f主題名稱;

                var q2 = (from m in db.t一般會員
                          where m.f會員編號 == article.f會員編號
                          select m).FirstOrDefault();
                article.會員名稱 = q2.f會員名稱;

                var q3 = (from l in db.t論壇文章留言
                          where l.f文章編號 == article.f文章編號
                          select l).Count();

                article.樓層數 = q3+1;

                    var q4 = (from m in db.t一般會員
                              where m.f會員編號 == article.f最新發表會員編號
                              select m).FirstOrDefault();

                    article.最新發表會員 = q4.f會員名稱;

            }
            return View(articles);
        }

        [HttpPost]
        public ActionResult ForumArticleList(t論壇文章資料表 art)
        {
            if (art.f文章標題 == null)
            {
                return RedirectToAction("ForumArticleList");
            }
            List<t論壇文章資料表> articles = new List<t論壇文章資料表>();
            if (art.f主題編號 != null){

                articles = (from article in db.t論壇文章資料表
                                where article.f文章標題.Contains(art.f文章標題)
                                && article.f主題編號 == art.f主題編號
                                orderby article.f最新發布時間 descending
                                select article).ToList();

                var q1 = (from t in db.t主題類型
                          where t.f主題編號 == art.f主題編號
                          select t).FirstOrDefault();
                ViewBag.topicName = q1.f主題名稱;
                ViewBag.topicid = art.f主題編號;

            }
            else {
                articles = (from article in db.t論壇文章資料表
                                where article.f文章標題.Contains(art.f文章標題)
                                orderby article.f最新發布時間 descending
                                select article).ToList();
                ViewBag.topicName = "全部";
            }


            foreach (t論壇文章資料表 article in articles)
            {
                var q1 = (from t in db.t主題類型
                          where t.f主題編號 == article.f主題編號
                          select t).FirstOrDefault();
                article.主題名稱 = q1.f主題名稱;

                var q2 = (from m in db.t一般會員
                          where m.f會員編號 == article.f會員編號
                          select m).FirstOrDefault();
                article.會員名稱 = q2.f會員名稱;

                var q3 = (from l in db.t論壇文章留言
                          where l.f文章編號 == article.f文章編號
                          select l).Count();

                article.樓層數 = q3 + 1;

                var q4 = (from m in db.t一般會員
                          where m.f會員編號 == article.f最新發表會員編號
                          select m).FirstOrDefault();

                article.最新發表會員 = q4.f會員名稱;

            }
            return View(articles);
        }

        public ActionResult ForumArticleDetail(string aId, string topicName, bool click = false)
        {
            List<t論壇文章資料表> list = new List<t論壇文章資料表> { };

            t論壇文章資料表 article = (from a in db.t論壇文章資料表 where a.f文章編號 == aId
                    select a).FirstOrDefault();
            ViewBag.topicName = topicName;
            //點閱率
            if (click == true) {
                article.f文章瀏覽數 += 1;
                db.SaveChanges();
            }

            //會員資料取得
            var q1 = (from m in db.t一般會員
                      where m.f會員編號 == article.f會員編號
                      select m).FirstOrDefault();
            article.會員名稱 = q1.f會員名稱;
            article.會員帳號 = q1.f會員帳號;
            article.會員頭像 = q1.f會員照片;
            article.現在樓層 = "樓主";
            list.Add(article);

            var q2 = (from m in db.t論壇文章留言
                      where m.f文章編號 == aId
                      orderby m.f留言編號
                      select m).ToList();

            if (q2.Count > 0) {
                int floor = 2;
                foreach (var x in q2) {
                    t論壇文章資料表 articleReply = new t論壇文章資料表();

                    articleReply.f文章編號 = aId;
                    articleReply.f主題編號 = article.f主題編號;
                    //articleReply.f文章標題 = article.f文章標題;
                    articleReply.f文章內容 = x.f留言內容;
                    articleReply.f發布時間 = x.f發布時間;
                    articleReply.f會員編號 = x.f會員編號;

                    var q3 = (from m in db.t一般會員
                              where m.f會員編號 == x.f會員編號
                              select m).FirstOrDefault();
                    articleReply.會員名稱 = q3.f會員名稱;
                    articleReply.會員帳號 = q3.f會員帳號;
                    articleReply.會員頭像 = q3.f會員照片;

                    articleReply.現在樓層 = floor + "樓";
                    floor++;
                    list.Add(articleReply);
                }
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult ForumArticleReply(t論壇文章留言 replyArticle)
        {
            string str_會員編號 = (Session["Member"] as t一般會員).f會員編號;
            replyArticle.f會員編號 = str_會員編號;
            replyArticle.f留言編號 = methodNewID.new留言編號();
            replyArticle.f發布時間 = DateTime.Now;

            db.t論壇文章留言.Add(replyArticle);

            var article = (from a in db.t論壇文章資料表
                           where a.f文章編號 == replyArticle.f文章編號
                    select a).FirstOrDefault();

            article.f最新發布時間     = replyArticle.f發布時間;
            article.f最新發表會員編號 = replyArticle.f會員編號;

            db.SaveChanges();
            string aId = replyArticle.f文章編號;
            return RedirectToAction("ForumArticleDetail", new {aId});
        }
    }
}