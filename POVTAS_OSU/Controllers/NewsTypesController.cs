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
    public class NewsTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewsTypes
        public ActionResult Index()
        {
            return View(db.NewsTypes.ToList());
        }

        // GET: NewsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsType newsType = db.NewsTypes.Find(id);
            if (newsType == null)
            {
                return HttpNotFound();
            }
            return View(newsType);
        }

        // GET: NewsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] NewsType newsType)
        {
            if (ModelState.IsValid)
            {
                db.NewsTypes.Add(newsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsType);
        }

        // GET: NewsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsType newsType = db.NewsTypes.Find(id);
            if (newsType == null)
            {
                return HttpNotFound();
            }
            return View(newsType);
        }

        // POST: NewsTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] NewsType newsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsType);
        }

        // GET: NewsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsType newsType = db.NewsTypes.Find(id);
            if (newsType == null)
            {
                return HttpNotFound();
            }
            return View(newsType);
        }

        // POST: NewsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsType newsType = db.NewsTypes.Find(id);
            db.NewsTypes.Remove(newsType);
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
