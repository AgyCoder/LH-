using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 竞赛老师系统;

namespace 竞赛老师系统.Areas.TeacherInfo.Controllers
{
    public class SCS_TeacherController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: TeacherInfo/SCS_Teacher
        public ActionResult Index()
        {
            return View(db.SCS_Teacher.ToList());
        }

        // GET: TeacherInfo/SCS_Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Teacher sCS_Teacher = db.SCS_Teacher.Find(id);
            if (sCS_Teacher == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Teacher);
        }

        // GET: TeacherInfo/SCS_Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherInfo/SCS_Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,姓名,职工号,手机号码,邮箱,办公地址")] SCS_Teacher sCS_Teacher)
        {
            if (ModelState.IsValid)
            {
                db.SCS_Teacher.Add(sCS_Teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_Teacher);
        }

        // GET: TeacherInfo/SCS_Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Teacher sCS_Teacher = db.SCS_Teacher.Find(id);
            if (sCS_Teacher == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Teacher);
        }

        // POST: TeacherInfo/SCS_Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,姓名,职工号,手机号码,邮箱,办公地址")] SCS_Teacher sCS_Teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_Teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_Teacher);
        }

        // GET: TeacherInfo/SCS_Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Teacher sCS_Teacher = db.SCS_Teacher.Find(id);
            if (sCS_Teacher == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Teacher);
        }

        // POST: TeacherInfo/SCS_Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCS_Teacher sCS_Teacher = db.SCS_Teacher.Find(id);
            db.SCS_Teacher.Remove(sCS_Teacher);
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

        

    }
}
