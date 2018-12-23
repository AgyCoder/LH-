using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛老师系统.Areas.fabu.Controllers
{
    public class IndexController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: fabu/Index
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Preservation(string project, string category, string content,string date)
        {


            SCS_Competition scS_Competition = new SCS_Competition
            {
                竞赛名称 = project,
                类别 = category,
                截止时间 = date,
                内容 = content,
                发布时间 = DateTime.Now.ToString()
            };
            int user_Login = Convert.ToInt32(Session["username"]);
            scS_Competition.职工号 =  user_Login;

            db.SCS_Competition.Add(scS_Competition);
            db.SaveChanges();

            return Json(true);
        }
    }
}