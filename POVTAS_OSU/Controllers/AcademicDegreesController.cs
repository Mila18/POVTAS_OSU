using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POVTAS_OSU.Models;

namespace POVTAS_OSU.Controllers
{
    [Authorize(Roles = "admin")]
    public class AcademicDegreesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcademicDegrees
        public ActionResult Index()
        {
            return View(db.AcademicDegrees.ToList());
        }

        // GET: AcademicDegrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicDegree academicDegree = db.AcademicDegrees.Find(id);
            if (academicDegree == null)
            {
                return HttpNotFound();
            }
            return View(academicDegree);
        }

        // GET: AcademicDegrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicDegrees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] AcademicDegree academicDegree)
        {
            if (ModelState.IsValid)
            {
                db.AcademicDegrees.Add(academicDegree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicDegree);
        }

        // GET: AcademicDegrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicDegree academicDegree = db.AcademicDegrees.Find(id);
            if (academicDegree == null)
            {
                return HttpNotFound();
            }
            return View(academicDegree);
        }

        // POST: AcademicDegrees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] AcademicDegree academicDegree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicDegree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicDegree);
        }

        // GET: AcademicDegrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicDegree academicDegree = db.AcademicDegrees.Find(id);
            if (academicDegree == null)
            {
                return HttpNotFound();
            }
            return View(academicDegree);
        }

        // POST: AcademicDegrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicDegree academicDegree = db.AcademicDegrees.Find(id);
            db.AcademicDegrees.Remove(academicDegree);
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
