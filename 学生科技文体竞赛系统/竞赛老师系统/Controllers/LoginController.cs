
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace 竞赛老师系统.Controllers
{
    public class LoginController : Controller
    {
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

        public JsonResult CheckPower(string username_v,string password_v)
        {
            int username = int.Parse(username_v);
            string password = password_v;
            Session["username"] = username;


            SCS_TeacherLogin sCS_TeacherLogin = db.SCS_TeacherLogin.Where (c=> c.职工号 == username && c.密码 == password).FirstOrDefault();
            if (sCS_TeacherLogin==null ) {
                return Json(null);
            }
            if (sCS_TeacherLogin.激活状态 == 0)
            {
                sCS_TeacherLogin.激活状态 = 1;
                return Json(0);
            }
           
                return Json(1);
        }

        public JsonResult CheckPower_Register(string password_1)
        {
            string password = password_1;
            int user_Login = Convert.ToInt32(Session["username"]);
            var result = db.SCS_TeacherLogin.SingleOrDefault(p => p.职工号 == user_Login);
            SCS_TeacherLogin tb = db.SCS_TeacherLogin.Find(result.id);
            tb.密码 = password;
            db.Entry(tb).State = EntityState.Modified;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;

            return Json(true);
        }

    }
}