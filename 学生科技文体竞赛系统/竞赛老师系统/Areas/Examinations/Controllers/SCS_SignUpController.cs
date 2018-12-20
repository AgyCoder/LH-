using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 竞赛老师系统;

namespace 竞赛老师系统.Areas.Examinations.Controllers
{
    public class SCS_SignUpController : Controller
    {
        private StudentsCompetitionSystemEntities db = new StudentsCompetitionSystemEntities();

        // GET: Examinations/SCS_SignUp
        public ActionResult Index()
        {
            return View(db.SCS_SignUp.ToList());
        }

        // GET: Examinations/SCS_SignUp/Details/5
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

        // GET: Examinations/SCS_SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examinations/SCS_SignUp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,姓名,班级,学号,学年成绩,电话,比赛项目,类别,邮箱,报名时间,团队人员姓名,审阅状态")] SCS_SignUp sCS_SignUp)
        {
            if (ModelState.IsValid)
            {
                db.SCS_SignUp.Add(sCS_SignUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sCS_SignUp);
        }

        // GET: Examinations/SCS_SignUp/Edit/5
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

        // POST: Examinations/SCS_SignUp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,姓名,班级,学号,学年成绩,电话,比赛项目,类别,邮箱,报名时间,团队人员姓名,审阅状态")] SCS_SignUp sCS_SignUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCS_SignUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCS_SignUp);
        }

        // GET: Examinations/SCS_SignUp/Delete/5
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

        // POST: Examinations/SCS_SignUp/Delete/5
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


        public JsonResult Table(int limit, int offset, string id)
        {
            try
            {
                var list = new List<SCS_SignUp>();
                var result = db.SCS_SignUp.Where(c => c.审阅状态 == 0);
                foreach (var item in result)
                {
                    SCS_SignUp tB = new SCS_SignUp
                    {
                        姓名 = item.姓名,
                        班级 = item.班级,
                        比赛项目 = item.比赛项目,
                        电话 = item.电话,
                        学年成绩 = item.学年成绩,
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

        public JsonResult GetUserMessage(int id)
        {
            var result = from r in db.SCS_SignUp
                         where (r.id == id)
                         select r;

            SCS_SignUp TB = new SCS_SignUp();
            foreach (var r in result)
            {
               
            }
            return Json(TB);
        }

    }
}
