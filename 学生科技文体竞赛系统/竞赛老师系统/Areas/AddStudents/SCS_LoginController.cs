using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 竞赛老师系统;

namespace 竞赛老师系统.Areas.AddStudents
{
    public class SCS_LoginController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: AddStudents/SCS_Login
        public ActionResult Index()
        {
            return View(db.SCS_Login.ToList());
        }

        // GET: AddStudents/SCS_Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Login sCS_Login = db.SCS_Login.Find(id);
            if (sCS_Login == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Login);
        }

        // GET: AddStudents/SCS_Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddStudents/SCS_Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,学号,密码,姓名,激活状态")] SCS_Login sCS_Login)
        {
            if (ModelState.IsValid)
            {
                db.SCS_Login.Add(sCS_Login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_Login);
        }

        // GET: AddStudents/SCS_Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Login sCS_Login = db.SCS_Login.Find(id);
            if (sCS_Login == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Login);
        }

        // POST: AddStudents/SCS_Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,学号,密码,姓名,激活状态")] SCS_Login sCS_Login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_Login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_Login);
        }

        // GET: AddStudents/SCS_Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_Login sCS_Login = db.SCS_Login.Find(id);
            if (sCS_Login == null)
            {
                return HttpNotFound();
            }
            return View(sCS_Login);
        }

        // POST: AddStudents/SCS_Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCS_Login sCS_Login = db.SCS_Login.Find(id);
            db.SCS_Login.Remove(sCS_Login);
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
