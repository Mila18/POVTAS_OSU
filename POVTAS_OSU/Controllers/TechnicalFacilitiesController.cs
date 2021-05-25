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
    public class TechnicalFacilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TechnicalFacilities
        public ActionResult Index()
        {
            var technicalFacilities = db.TechnicalFacilities.Include(t => t.Classroom);
            return View(technicalFacilities.ToList());
        }

        // GET: TechnicalFacilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFacility technicalFacility = db.TechnicalFacilities.Find(id);
            if (technicalFacility == null)
            {
                return HttpNotFound();
            }
            return View(technicalFacility);
        }

        // GET: TechnicalFacilities/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "Number");
            return View();
        }

        // POST: TechnicalFacilities/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Configuration,ClassroomId")] TechnicalFacility technicalFacility)
        {
            if (ModelState.IsValid)
            {
                db.TechnicalFacilities.Add(technicalFacility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "Description", technicalFacility.ClassroomId);
            return View(technicalFacility);
        }

        // GET: TechnicalFacilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFacility technicalFacility = db.TechnicalFacilities.Find(id);
            if (technicalFacility == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "Description", technicalFacility.ClassroomId);
            return View(technicalFacility);
        }

        // POST: TechnicalFacilities/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Configuration,ClassroomId")] TechnicalFacility technicalFacility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicalFacility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomId = new SelectList(db.Classrooms, "Id", "Description", technicalFacility.ClassroomId);
            return View(technicalFacility);
        }

        // GET: TechnicalFacilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFacility technicalFacility = db.TechnicalFacilities.Find(id);
            if (technicalFacility == null)
            {
                return HttpNotFound();
            }
            return View(technicalFacility);
        }

        // POST: TechnicalFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicalFacility technicalFacility = db.TechnicalFacilities.Find(id);
            db.TechnicalFacilities.Remove(technicalFacility);
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
