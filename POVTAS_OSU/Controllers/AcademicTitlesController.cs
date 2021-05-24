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
    public class AcademicTitlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcademicTitles
        public ActionResult Index()
        {
            return View(db.AcademicTitles.ToList());
        }

        // GET: AcademicTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicTitle academicTitle = db.AcademicTitles.Find(id);
            if (academicTitle == null)
            {
                return HttpNotFound();
            }
            return View(academicTitle);
        }

        // GET: AcademicTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicTitles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] AcademicTitle academicTitle)
        {
            if (ModelState.IsValid)
            {
                db.AcademicTitles.Add(academicTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicTitle);
        }

        // GET: AcademicTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicTitle academicTitle = db.AcademicTitles.Find(id);
            if (academicTitle == null)
            {
                return HttpNotFound();
            }
            return View(academicTitle);
        }

        // POST: AcademicTitles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] AcademicTitle academicTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicTitle);
        }

        // GET: AcademicTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicTitle academicTitle = db.AcademicTitles.Find(id);
            if (academicTitle == null)
            {
                return HttpNotFound();
            }
            return View(academicTitle);
        }

        // POST: AcademicTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicTitle academicTitle = db.AcademicTitles.Find(id);
            db.AcademicTitles.Remove(academicTitle);
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
