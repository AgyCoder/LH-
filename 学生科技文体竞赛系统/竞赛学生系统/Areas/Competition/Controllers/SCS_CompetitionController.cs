using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 竞赛学生系统;

namespace 竞赛学生系统.Areas.Competition.Controllers
{
    public class SCS_CompetitionController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: Competition/SCS_Competition
        public ActionResult Index()
        {
            return View(db.SCS_Competition.ToList());
        }

        // GET: Competition/SCS_Competition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Competition sCS_Competition = db.SCS_Competition.Find(id);
            if (sCS_Competition == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Competition);
        }

        // GET: Competition/SCS_Competition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competition/SCS_Competition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,名称,竞赛名称,类别,内容,发布时间,截止时间,逻辑删除,职工号")] SCS_Competition sCS_Competition)
        {
            if (ModelState.IsValid)
            {
                db.SCS_Competition.Add(sCS_Competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_Competition);
        }

        // GET: Competition/SCS_Competition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Competition sCS_Competition = db.SCS_Competition.Find(id);
            if (sCS_Competition == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Competition);
        }

        // POST: Competition/SCS_Competition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,名称,竞赛名称,类别,内容,发布时间,截止时间,逻辑删除,职工号")] SCS_Competition sCS_Competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_Competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_Competition);
        }

        // GET: Competition/SCS_Competition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Competition sCS_Competition = db.SCS_Competition.Find(id);
            if (sCS_Competition == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Competition);
        }

        // POST: Competition/SCS_Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCS_Competition sCS_Competition = db.SCS_Competition.Find(id);
            db.SCS_Competition.Remove(sCS_Competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Table(int limit, int offset,string name)
        {
            try
            {

                //var list = new List<SCS_Competition>();
                //var result = from m in db.SCS_Competition select m;
                //foreach (var item in result)
                //{
                //    SCS_Competition sCS_Competition = new SCS_Competition
                //    {
                //        竞赛名称 = item.竞赛名称,
                //        类别 = item.类别,
                //        名称 = item.名称,
                //        内容 = item.内容,
                //        发布时间 = item.发布时间,
                //        截止时间 = item.截止时间,
                //        id = item.id,
                //        职工号 = item.职工号

                //    };
                //    list.Add(sCS_Competition);
                //}
                var m = db.SCS_Competition;
                List<SCS_Competition> list = db.SCS_Competition.Where(c => c.竞赛名称.Contains(name)).ToList();
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
