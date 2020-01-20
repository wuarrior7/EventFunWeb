
using EventFunWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewIDMethod.Class
{
    public class methodNewID
    {
        public static int new會員喜愛次主題編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t會員喜愛次主題
                         orderby t.f會員喜愛次主題流水號 descending
                         select t.f會員喜愛次主題流水號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }

        }
        public static int new喜愛活動編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t會員喜愛活動
                         orderby t.f喜愛活動流水號 descending
                         select t.f喜愛活動流水號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }

        }
        public static int new廣告編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t廣告
                         orderby t.f廣告編號 descending
                         select t.f廣告編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }

        }
        public static string new一般會員編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            string str_會員前9碼 = "M" + DateTime.Now.ToString("yyyyMMdd");
            try
            {
                var q = (from t in db.t一般會員
                        where t.f會員編號.Contains(str_會員前9碼)
                        orderby t.f會員編號 descending
                        select t.f會員編號).FirstOrDefault();
                int int_會員編碼 = 0;
                if (int.TryParse(q.Substring(11), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(11))+1;
                if (int.TryParse(q.Substring(10,2), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(10,2))+1;
                if (int.TryParse(q.Substring(9, 3), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(9, 3))+1;


                if (int_會員編碼 < 10)
                    return "M" + DateTime.Now.ToString("yyyyMMdd") + "00" + int_會員編碼;
                if (int_會員編碼 < 100)
                    return "M" + DateTime.Now.ToString("yyyyMMdd") + "0" + int_會員編碼;
                else
                    return "M" + DateTime.Now.ToString("yyyyMMdd") + int_會員編碼;
            }
            catch
            {
                return "M" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
        }
        public static string new企業會員編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            string str_會員前9碼 = "C" + DateTime.Now.ToString("yyyyMMdd");
            try
            {
                var q = (from t in db.t企業會員
                        where t.f企業編號.Contains(str_會員前9碼)
                        orderby t.f企業編號 descending
                        select t.f企業編號).FirstOrDefault();
                int int_會員編碼 = 0;
                if (int.TryParse(q.Substring(11), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(11)) + 1;
                if (int.TryParse(q.Substring(10, 2), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(10, 2)) + 1;
                if (int.TryParse(q.Substring(9, 3), out int_會員編碼))
                    int_會員編碼 = int.Parse(q.Substring(9, 3)) + 1;
                if (int_會員編碼 < 10)
                    return "C" + DateTime.Now.ToString("yyyyMMdd") + "00" + int_會員編碼;
                if (int_會員編碼 < 100)
                    return "C" + DateTime.Now.ToString("yyyyMMdd") + "0" + int_會員編碼;
                else
                    return "C" + DateTime.Now.ToString("yyyyMMdd") + int_會員編碼;
            }
            catch
            {
                return "C" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
        }
        public static string new活動編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            string str_活動前9碼 = "E" + DateTime.Now.ToString("yyyyMMdd");
            try
            {
                var q = (from t in db.t活動
                        where t.f活動編號.Contains(str_活動前9碼)
                        orderby t.f活動編號 descending
                        select t.f活動編號).FirstOrDefault();
                int int_活動編碼 = 0;
                if (int.TryParse(q.Substring(11), out int_活動編碼))
                    int_活動編碼 = int.Parse(q.Substring(11)) + 1;
                if (int.TryParse(q.Substring(10, 2), out int_活動編碼))
                    int_活動編碼 = int.Parse(q.Substring(10, 2)) + 1;
                if (int.TryParse(q.Substring(9, 3), out int_活動編碼))
                    int_活動編碼 = int.Parse(q.Substring(9, 3)) + 1;
                if (int_活動編碼 < 10)
                    return "E" + DateTime.Now.ToString("yyyyMMdd") + "00" + int_活動編碼;
                if (int_活動編碼 < 100)
                    return "E" + DateTime.Now.ToString("yyyyMMdd") + "0" + int_活動編碼;
                else
                    return "E" + DateTime.Now.ToString("yyyyMMdd") + int_活動編碼;
            }
            catch
            {
                return "E" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
        }
        public static int new活動圖片編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t活動圖片
                         orderby t.f圖片編號 descending

                         select t.f圖片編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }
        }
        public static string new活動日期編號(string str_活動編號)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t活動日期
                        where t.f活動日期編號.Contains(str_活動編號)
                        orderby t.f活動日期編號 descending
                        select t.f活動日期編號).FirstOrDefault();
                int int_活動日期編碼 = 0;
                if (int.TryParse(q.Substring(15), out int_活動日期編碼))
                    int_活動日期編碼 = int.Parse(q.Substring(15)) + 1;
                if (int.TryParse(q.Substring(14, 2), out int_活動日期編碼))
                    int_活動日期編碼 = int.Parse(q.Substring(14, 2)) + 1;
                if (int.TryParse(q.Substring(13, 3), out int_活動日期編碼))
                    int_活動日期編碼 = int.Parse(q.Substring(13, 3)) + 1;
                if (int_活動日期編碼 < 10)
                    return str_活動編號 + "D00" + int_活動日期編碼;
                if (int_活動日期編碼 < 100)
                    return str_活動編號 + "D0" + int_活動日期編碼;
                else
                    return str_活動編號 + "D" + int_活動日期編碼;
            }
            catch
            {
                return str_活動編號 + "D001";
            }
        }
        public static string new活動場次編號(string str_活動日期編號)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t活動場次
                        where t.f場次編號.Contains(str_活動日期編號)
                        orderby t.f場次編號 descending
                        select t.f場次編號).FirstOrDefault();
                int int_活動場次編碼 = 0;
                if (int.TryParse(q.Substring(19), out int_活動場次編碼))
                    int_活動場次編碼 = int.Parse(q.Substring(19)) + 1;
                if (int.TryParse(q.Substring(18, 2), out int_活動場次編碼))
                    int_活動場次編碼 = int.Parse(q.Substring(18, 2)) + 1;
                
                if (int_活動場次編碼 < 10)
                    return str_活動日期編號 + "SS0" + int_活動場次編碼;
                else 
                    return str_活動日期編號 + "SS" + int_活動場次編碼;
            }
            catch
            {
                return str_活動日期編號 + "SS01";
            }
        }
        public static string new活動票券編號(string str_活動場次編號)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t活動票券
                        where t.f票券編號.Contains(str_活動場次編號)
                        orderby t.f票券編號 descending
                        select t.f票券編號).FirstOrDefault();
                int int_活動票券編碼 = 0;
                if (int.TryParse(q.Substring(23), out int_活動票券編碼))
                    int_活動票券編碼 = int.Parse(q.Substring(23)) + 1;
                if (int.TryParse(q.Substring(22, 2), out int_活動票券編碼))
                    int_活動票券編碼 = int.Parse(q.Substring(22, 2)) + 1;
                if (int_活動票券編碼 < 10)
                    return str_活動場次編號 + "TK0" + int_活動票券編碼;
                else
                    return str_活動場次編號 + "TK" + int_活動票券編碼;
            }
            catch
            {
                return str_活動場次編號 + "TK01";
            }
        }
        public static int new評鑑編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t評鑑
                         orderby t.f評鑑編號 descending
                         select t.f評鑑編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }

        }
        public static string new票券訂單編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            string str_票券訂單前10碼 = "TO" + DateTime.Now.ToString("yyyyMMdd");
            try
            {
                var q = (from t in db.t票券訂單
                        where t.f票券訂單編號.Contains(str_票券訂單前10碼)
                        orderby t.f票券訂單編號 descending
                        select t.f票券訂單編號).FirstOrDefault();
                int int_票券訂單編碼 = 0;
                if (int.TryParse(q.Substring(11), out int_票券訂單編碼))
                    int_票券訂單編碼 = int.Parse(q.Substring(11)) + 1;
                if (int.TryParse(q.Substring(10, 2), out int_票券訂單編碼))
                    int_票券訂單編碼 = int.Parse(q.Substring(10, 2)) + 1;
                if (int_票券訂單編碼 < 10)
                    return "TO" + DateTime.Now.ToString("yyyyMMdd") + "0" + int_票券訂單編碼;
                else 
                    return "TO" + DateTime.Now.ToString("yyyyMMdd") + int_票券訂單編碼;
              
            }
            catch
            {
                return "TO" + DateTime.Now.ToString("yyyyMMdd") + "01";
            }
        }
        public static string new主題類型編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            
            try
            {
                var q = (from t in db.t主題類型
                        orderby t.f主題編號 descending
                        select t.f主題編號).FirstOrDefault();
                int int_主題類型尾碼 = 0;
                if (int.TryParse(q.Substring(3), out int_主題類型尾碼))
                    int_主題類型尾碼 = int.Parse(q.Substring(3)) + 1;
                if (int.TryParse(q.Substring(2, 2), out int_主題類型尾碼))
                    int_主題類型尾碼 = int.Parse(q.Substring(2, 2)) + 1;
                if (int_主題類型尾碼 < 10)
                    return "PE"+ "0" + int_主題類型尾碼;
                else
                    return "PE" + int_主題類型尾碼;
                
            }
            catch

            {
                return "PE01";
            }
        }
        public static string new次主題編號(string str_主題類型編號)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t次主題類型
                        where t.f次主題編號.Contains(str_主題類型編號)
                        orderby t.f次主題編號 descending
                        select t.f次主題編號).FirstOrDefault();
                int int_次主題編碼 = 0;
                if (int.TryParse(q.Substring(7), out int_次主題編碼))
                    int_次主題編碼 = int.Parse(q.Substring(7)) + 1;
                if (int.TryParse(q.Substring(6, 2), out int_次主題編碼))
                    int_次主題編碼 = int.Parse(q.Substring(6, 2)) + 1;
                if (int_次主題編碼 < 10)
                    return str_主題類型編號 + "CE0" + int_次主題編碼;
                else
                    return str_主題類型編號 + "CE" + int_次主題編碼;
            }
            catch
            {
                return str_主題類型編號 + "CE01"; 
            }
        }
        public static string new行事曆編號(string str_一般會員編號)
        {
            return "CL" + str_一般會員編號;
        }
        public static int new行事曆明細編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t行事曆明細
                         orderby t.f行事曆明細編號 descending
                         select t.f行事曆明細編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }
        }
        public static int new管理者編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t管理者資料表
                         orderby t.f管理者編號 descending
                         select t.f管理者編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }
        }
        public static string new文章編號(string str_主題編號)
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t論壇文章資料表
                         where t.f文章編號.Contains(str_主題編號)
                         orderby t.f文章編號 descending
                         select t.f文章編號).FirstOrDefault();
                int int_文章編碼 = 0;
                if (int.TryParse(q.Substring(7), out int_文章編碼))
                    int_文章編碼 = int.Parse(q.Substring(7)) + 1;
                if (int.TryParse(q.Substring(6, 2), out int_文章編碼))
                    int_文章編碼 = int.Parse(q.Substring(6, 2)) + 1;
                if (int_文章編碼 < 10)
                    return "AT"+str_主題編號 + "0" + int_文章編碼;
                else
                    return "AT"+str_主題編號 + int_文章編碼;
            }
            catch
            {
                return "AT"+str_主題編號 + "01";
            }
        }
        public static int new留言編號()
        {
            dbEventFunEntities db = new dbEventFunEntities();
            try
            {
                var q = (from t in db.t論壇文章留言
                         orderby t.f留言編號 descending
                         select t.f留言編號).FirstOrDefault();
                return q + 1;
            }
            catch
            {
                return 1;
            }

        }
    }
}