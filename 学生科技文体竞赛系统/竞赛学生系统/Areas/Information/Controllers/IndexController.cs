using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 竞赛学生系统.Areas.Information.Controllers
{
    public class IndexController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();
        // GET: Information/Index
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Table(int limit, int offset, string name)
        {
            try
            {
                
                var m = db.SCS_Message;
                List<SCS_Message> list = db.SCS_Message.Where(c => c.发件人.Contains(name)).ToList();
                var total = list.Count;
                var rows = list.Skip(offset).Take(limit).ToList();
                return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}