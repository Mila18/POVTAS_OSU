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
    public class CalendarOfEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CalendarOfEvents
        public ActionResult Index()
        {
            var calendarOfEvents = db.CalendarOfEvents.Include(c => c.EventReportOf);
            return View(calendarOfEvents.ToList());
        }

        // GET: CalendarOfEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarOfEvent calendarOfEvent = db.CalendarOfEvents.Find(id);
            if (calendarOfEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarOfEvent);
        }

        // GET: CalendarOfEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventReportId = new SelectList(db.EventReports, "Id", "Report");
            return View();
        }

        // POST: CalendarOfEvents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventReportId,Id,Event,Date")] CalendarOfEvent calendarOfEvent)
        {
            if (ModelState.IsValid)
            {
                db.CalendarOfEvents.Add(calendarOfEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventReportId = new SelectList(db.EventReports, "Id", "Report", calendarOfEvent.EventReportId);
            return View(calendarOfEvent);
        }

        // GET: CalendarOfEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarOfEvent calendarOfEvent = db.CalendarOfEvents.Find(id);
            if (calendarOfEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventReportId = new SelectList(db.EventReports, "Id", "Report", calendarOfEvent.EventReportId);
            return View(calendarOfEvent);
        }

        // POST: CalendarOfEvents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventReportId,Id,Event,Date")] CalendarOfEvent calendarOfEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarOfEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventReportId = new SelectList(db.EventReports, "Id", "Report", calendarOfEvent.EventReportId);
            return View(calendarOfEvent);
        }

        // GET: CalendarOfEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarOfEvent calendarOfEvent = db.CalendarOfEvents.Find(id);
            if (calendarOfEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarOfEvent);
        }

        // POST: CalendarOfEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarOfEvent calendarOfEvent = db.CalendarOfEvents.Find(id);
            db.CalendarOfEvents.Remove(calendarOfEvent);
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
