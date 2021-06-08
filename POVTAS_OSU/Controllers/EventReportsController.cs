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
    public class EventReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventReports
        public ActionResult Index()
        {
            var eventReports = db.EventReports.Include(e => e.CalendarOfEvent);
            return View(eventReports.ToList());
        }

        // GET: EventReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReport eventReport = db.EventReports.Find(id);
            if (eventReport == null)
            {
                return HttpNotFound();
            }
            return View(eventReport);
        }

        // GET: EventReports/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.CalendarOfEvents, "EventReportId", "Event");
            return View();
        }

        // POST: EventReports/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReportFile,Date")]HttpPostedFileBase ReportFile, EventReport eventReport)
        {
            if (ModelState.IsValid)
            {
                if (ReportFile != null)
                {
                    string filename = ReportFile.FileName;
                    ReportFile.SaveAs(Server.MapPath("/Files/" + filename));
                    eventReport.ReportFile = "/Files/" + filename;
                }
                db.EventReports.Add(eventReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.CalendarOfEvents, "EventReportId", "Event", eventReport.Id);
            return View(eventReport);
        }

        // GET: EventReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReport eventReport = db.EventReports.Find(id);
            if (eventReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.CalendarOfEvents, "EventReportId", "Event", eventReport.Id);
            return View(eventReport);
        }

        // POST: EventReports/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReportFile,Date")]HttpPostedFileBase ReportFile, EventReport eventReport, string oldFile)
        {
            if (ModelState.IsValid)
            {
                if (ReportFile != null)
                {
                    string filename = ReportFile.FileName;
                    ReportFile.SaveAs(Server.MapPath("/Files/" + filename));
                    eventReport.ReportFile = "/Files/" + filename;
                }
                else eventReport.ReportFile = oldFile;
                db.Entry(eventReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.CalendarOfEvents, "EventReportId", "Event", eventReport.Id);
            return View(eventReport);
        }

        // GET: EventReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReport eventReport = db.EventReports.Find(id);
            if (eventReport == null)
            {
                return HttpNotFound();
            }
            return View(eventReport);
        }

        // POST: EventReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventReport eventReport = db.EventReports.Find(id);
            db.EventReports.Remove(eventReport);
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
