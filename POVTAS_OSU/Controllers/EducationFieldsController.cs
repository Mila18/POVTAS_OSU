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
    public class EducationFieldsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EducationFields
        public ActionResult Index()
        {
            return View(db.EducationFields.ToList());
        }

        // GET: EducationFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationField educationField = db.EducationFields.Find(id);
            if (educationField == null)
            {
                return HttpNotFound();
            }
            return View(educationField);
        }

        // GET: EducationFields/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationFields/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ChairId")] EducationField educationField)
        {
            if (ModelState.IsValid)
            {
                db.EducationFields.Add(educationField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationField);
        }

        // GET: EducationFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationField educationField = db.EducationFields.Find(id);
            if (educationField == null)
            {
                return HttpNotFound();
            }
            return View(educationField);
        }

        // POST: EducationFields/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ChairId")] EducationField educationField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationField);
        }

        // GET: EducationFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationField educationField = db.EducationFields.Find(id);
            if (educationField == null)
            {
                return HttpNotFound();
            }
            return View(educationField);
        }

        // POST: EducationFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationField educationField = db.EducationFields.Find(id);
            db.EducationFields.Remove(educationField);
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
