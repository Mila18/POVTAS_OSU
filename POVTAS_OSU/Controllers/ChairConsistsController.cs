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
    public class ChairConsistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChairConsists
        public ActionResult Index()
        {
            var chairConsists = db.ChairConsists.Include(c => c.AcademicDegree).Include(c => c.AcademicTitle).Include(c => c.Activity).Include(c => c.Position);
            return View(chairConsists.ToList());
        }

        // GET: ChairConsists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChairConsist chairConsist = db.ChairConsists.Find(id);
            if (chairConsist == null)
            {
                return HttpNotFound();
            }
            return View(chairConsist);
        }

        // GET: ChairConsists/Create
        public ActionResult Create()
        {
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title");
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title");
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title");
            return View();
        }

        // POST: ChairConsists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,ActivityId,AcademicTitleId,AcademicDegreeId,PositionId,ChairId")] ChairConsist chairConsist)
        {
            if (ModelState.IsValid)
            {
                db.ChairConsists.Add(chairConsist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            return View(chairConsist);
        }

        // GET: ChairConsists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChairConsist chairConsist = db.ChairConsists.Find(id);
            if (chairConsist == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            return View(chairConsist);
        }

        // POST: ChairConsists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,ActivityId,AcademicTitleId,AcademicDegreeId,PositionId,ChairId")] ChairConsist chairConsist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chairConsist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            return View(chairConsist);
        }

        // GET: ChairConsists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChairConsist chairConsist = db.ChairConsists.Find(id);
            if (chairConsist == null)
            {
                return HttpNotFound();
            }
            return View(chairConsist);
        }

        // POST: ChairConsists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChairConsist chairConsist = db.ChairConsists.Find(id);
            db.ChairConsists.Remove(chairConsist);
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
