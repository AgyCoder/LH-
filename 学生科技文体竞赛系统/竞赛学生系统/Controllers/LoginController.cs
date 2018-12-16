using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛学生系统.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult test()
        {

            return View();
        }


        public ActionResult Register()
        {

            return View();
        }

        public JsonResult CheckPower(string username_v, string password_v)
        {
            int username = int.Parse(username_v);
            string password = password_v;
            Session["username"] = username;


            SCS_Login sCS_Login = db.SCS_Login.Where(c => c.学号 == username && c.密码 == password).FirstOrDefault();
            if (sCS_Login == null)
            {
                string str = "用户名或者密码错误！";
                ViewBag.error = str;
                ViewBag.FormAction = "CheckPower";
                ViewBag.userId = username;
                return Json(false);
            }

            return Json(true);
        }
        public JsonResult CheckPower_Register(string password_1)
        {
            string password = password_1;
            int user_Login = Convert.ToInt32(Session["username"]);
            var result = db.SCS_Login.SingleOrDefault(p => p.学号 == user_Login);
            SCS_Login tb = db.SCS_Login.Find(result.id);
            tb.密码 = password;
            db.Entry(tb).State = EntityState.Modified;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;

            return Json(true);
        }
    }
}