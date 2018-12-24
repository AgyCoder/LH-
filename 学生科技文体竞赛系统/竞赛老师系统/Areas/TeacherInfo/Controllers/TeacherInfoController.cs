using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛老师系统.Areas.TeacherInfo.Controllers
{
    public class TeacherInfoController : Controller
    {
        private static StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: TeacherInfo/TeacherInfo
        public ActionResult Index()
        {
            return View();
        }

        public static SCS_Teacher Get_TeacherInfo(int id)
        {
            try
            {
                
                SCS_Teacher sCS_Teacher = new SCS_Teacher();
                var result1 = db.SCS_Teacher.Where(c => c.职工号.Equals(id)).Distinct();
                if (result1.Count() > 0)
                {
                    foreach (var r in result1)
                    {
                        //view_Userinfo.驾驶证号码 = r.驾驶证号码;
                        sCS_Teacher.职工号 = r.职工号;
                        sCS_Teacher.姓名 = r.姓名;
                        sCS_Teacher.手机号码 = r.手机号码;
                        sCS_Teacher.邮箱 = r.邮箱;
                        sCS_Teacher.办公地址 = r.办公地址;
                    }
                }
                
                return sCS_Teacher;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public JsonResult GetMessage()
        {
            SCS_Teacher user = new SCS_Teacher();

           return Json(TeacherInfoController.Get_TeacherInfo(Convert.ToInt32(Session["id"])));
        }

        public JsonResult Revise(string name,int tel,string Email ,string Office)
        {

            SCS_Teacher sCS_Teacher = db.SCS_Teacher.Where(c => c.职工号.Equals(Convert.ToInt32(Session["id"]))).FirstOrDefault();
            sCS_Teacher.姓名 = name;
            sCS_Teacher.手机号码 = tel;
            sCS_Teacher.邮箱 = Email;
            sCS_Teacher.办公地址 = Office;
            db.SCS_Teacher.Add(sCS_Teacher);
            db.SaveChanges();

            return Json(true);
        }
    }
}