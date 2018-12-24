using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛老师系统.Areas.FeedBackMsg.Controllers
{
    public class MsgController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: FeedBackMsg/Msg
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Table(int limit, int offset)
        {
            try
            {
                int teaid = Convert.ToInt32(Session["username"]);
                var name = db.SCS_TeacherLogin.Where(c => c.职工号 == teaid).First().姓名;
                var list = db.SCS_Message.Where(c => c.发件人.Equals(name)).ToList();
                var total = list.Count;
                var rows = list.Skip(offset).Take(limit).ToList();
                return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}