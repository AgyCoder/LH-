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
    public class SCS_SignUpController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: Competition/SCS_SignUp
        public ActionResult Index()
        {
            return View(db.SCS_SignUp.ToList());
        }

        // GET: Competition/SCS_SignUp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_SignUp sCS_SignUp = db.SCS_SignUp.Find(id);
            if (sCS_SignUp == null)
            {
                return HttpNotFound();
            }
            return View(sCS_SignUp);
        }

        // GET: Competition/SCS_SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competition/SCS_SignUp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,姓名,班级,学号,学年成绩,电话,比赛项目,类别,邮箱,报名时间,团队人员姓名,审阅状态,职工号")] SCS_SignUp sCS_SignUp)
        {
            if (ModelState.IsValid)
            {
                db.SCS_SignUp.Add(sCS_SignUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_SignUp);
        }

        // GET: Competition/SCS_SignUp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_SignUp sCS_SignUp = db.SCS_SignUp.Find(id);
            if (sCS_SignUp == null)
            {
                return HttpNotFound();
            }
            return View(sCS_SignUp);
        }

        // POST: Competition/SCS_SignUp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,姓名,班级,学号,学年成绩,电话,比赛项目,类别,邮箱,报名时间,团队人员姓名,审阅状态,职工号")] SCS_SignUp sCS_SignUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_SignUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_SignUp);
        }

        // GET: Competition/SCS_SignUp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCS_SignUp sCS_SignUp = db.SCS_SignUp.Find(id);
            if (sCS_SignUp == null)
            {
                return HttpNotFound();
            }
            return View(sCS_SignUp);
        }

        // POST: Competition/SCS_SignUp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCS_SignUp sCS_SignUp = db.SCS_SignUp.Find(id);
            db.SCS_SignUp.Remove(sCS_SignUp);
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
