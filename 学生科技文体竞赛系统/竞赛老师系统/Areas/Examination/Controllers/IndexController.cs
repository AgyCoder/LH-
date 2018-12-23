using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛老师系统.Areas.Examination.Controllers
{
    //进行同步更改
    public class IndexController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: Examination/Index
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Table(int limit, int offset, string id)
        {
            try
            {
                var list = new List<SCS_SignUp>();
                var result = from m in db.SCS_SignUp
                             where m.审阅状态==0
                             select m;
                foreach (var item in result)
                {
                    SCS_SignUp tB = new SCS_SignUp
                    {
                        姓名 = item.姓名,
                        班级 = item.班级,
                        学号 = item.学号,
                        电话 = item.电话,
                        学年成绩 = item.学年成绩,
                        id=item.id
                    };
                    list.Add(tB);
                }

                var total = list.Count;
                var rows = list.Skip(offset).Take(limit).ToList();
                return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult adopt()
        {

            return View();
        }

        public JsonResult Table_adpot(int limit, int offset)
        {
            try
            {
                int user_Login = Convert.ToInt32(Session["username"]);
                var list = new List<SCS_SignUp>();
                var result =  db.SCS_SignUp.Where(c => c.审阅状态 == user_Login);
                             //where m.审阅状态>1
                             //select m;
                foreach (var item in result)
                {
                    SCS_SignUp tB = new SCS_SignUp();
                    //{


                    //    姓名 = item.姓名,
                    //    班级 = item.班级,
                    //    学号 = item.学号,
                    //    电话 = item.电话,
                    //    学年成绩 = item.学年成绩,
                    //    id = item.id
                    //};
                    list.Add(tB);
                }

                var total = list.Count;
                var rows = list.Skip(offset).Take(limit).ToList();
                return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public JsonResult Detailed(int row_id)//详细
        {

            return Json(true);
        }

        public JsonResult Via(int row_id)//通过
        {
            var result = db.SCS_SignUp.SingleOrDefault(c => c.id == row_id);
            SCS_SignUp tB = db.SCS_SignUp.Find(result.id);
            tB.审阅状态 = Convert.ToInt32(Session["username"]);
            db.Entry(tB).State = EntityState.Modified;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;

            return Json(tB.审阅状态);
        }


        public JsonResult Retreat(int row_id)//退回
        {
            var result = db.SCS_SignUp.SingleOrDefault(c => c.id == row_id);
            SCS_SignUp tB = db.SCS_SignUp.Find(result.id);
            tB.审阅状态 = -1;
            db.Entry(tB).State = EntityState.Modified;

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
            

            return Json(true);
        }
    }
}