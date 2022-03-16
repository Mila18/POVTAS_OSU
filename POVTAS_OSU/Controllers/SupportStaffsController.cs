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
    public class SupportStaffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupportStaffs
        public ActionResult Index()
        {
            var supportStaffs = db.SupportStaffs.Include(s => s.Position);
            return View(supportStaffs.ToList());
        }

        // GET: SupportStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportStaff supportStaff = db.SupportStaffs.Find(id);
            if (supportStaff == null)
            {
                return HttpNotFound();
            }
            return View(supportStaff);
        }

        // GET: SupportStaffs/Create
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title");
            return View();
        }

        // POST: SupportStaffs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,Education,Photo,PositionId,ChairId")] SupportStaff supportStaff)
        {
            if (ModelState.IsValid)
            {
                db.SupportStaffs.Add(supportStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", supportStaff.PositionId);
            return View(supportStaff);
        }

        // GET: SupportStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportStaff supportStaff = db.SupportStaffs.Find(id);
            if (supportStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", supportStaff.PositionId);
            return View(supportStaff);
        }

        // POST: SupportStaffs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,Education,Photo,PositionId,ChairId")] SupportStaff supportStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", supportStaff.PositionId);
            return View(supportStaff);
        }

        // GET: SupportStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportStaff supportStaff = db.SupportStaffs.Find(id);
            if (supportStaff == null)
            {
                return HttpNotFound();
            }
            return View(supportStaff);
        }

        // POST: SupportStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportStaff supportStaff = db.SupportStaffs.Find(id);
            db.SupportStaffs.Remove(supportStaff);
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
