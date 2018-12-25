using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 竞赛老师系统;

namespace 竞赛老师系统.Areas.AddTeachers
{
    public class SCS_TeacherLoginController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: AddTeachers/SCS_TeacherLogin
        public ActionResult Index()
        {
            return View(db.SCS_TeacherLogin.ToList());
        }

        // GET: AddTeachers/SCS_TeacherLogin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_TeacherLogin sCS_TeacherLogin = db.SCS_TeacherLogin.Find(id);
            if (sCS_TeacherLogin == null)
            {
                return HttpNotFound();
            }
            return View(sCS_TeacherLogin);
        }

        // GET: AddTeachers/SCS_TeacherLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddTeachers/SCS_TeacherLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,姓名,职工号,密码,激活状态")] SCS_TeacherLogin sCS_TeacherLogin)
        {
            if (ModelState.IsValid)
            {
                db.SCS_TeacherLogin.Add(sCS_TeacherLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_TeacherLogin);
        }

        // GET: AddTeachers/SCS_TeacherLogin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_TeacherLogin sCS_TeacherLogin = db.SCS_TeacherLogin.Find(id);
            if (sCS_TeacherLogin == null)
            {
                return HttpNotFound();
            }
            return View(sCS_TeacherLogin);
        }

        // POST: AddTeachers/SCS_TeacherLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,姓名,职工号,密码,激活状态")] SCS_TeacherLogin sCS_TeacherLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_TeacherLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_TeacherLogin);
        }

        // GET: AddTeachers/SCS_TeacherLogin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_TeacherLogin sCS_TeacherLogin = db.SCS_TeacherLogin.Find(id);
            if (sCS_TeacherLogin == null)
            {
                return HttpNotFound();
            }
            return View(sCS_TeacherLogin);
        }

        // POST: AddTeachers/SCS_TeacherLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCS_TeacherLogin sCS_TeacherLogin = db.SCS_TeacherLogin.Find(id);
            db.SCS_TeacherLogin.Remove(sCS_TeacherLogin);
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
