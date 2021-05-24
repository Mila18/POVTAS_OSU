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
    public class ChairsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chairs
        public ActionResult Index()
        {
            var chairs = db.Chairs.Include(c => c.ContactOf);
            return View(chairs.ToList());
        }

        // GET: Chairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // GET: Chairs/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Address");
            return View();
        }

        // POST: Chairs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Id,Title,Abbreviation")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                db.Chairs.Add(chair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Address", chair.ContactId);
            return View(chair);
        }

        // GET: Chairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Address", chair.ContactId);
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Id,Title,Abbreviation")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Address", chair.ContactId);
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chair chair = db.Chairs.Find(id);
            if (chair == null)
            {
                return HttpNotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chair chair = db.Chairs.Find(id);
            db.Chairs.Remove(chair);
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
