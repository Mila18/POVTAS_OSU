﻿using System;
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
    public class MaterialSupportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaterialSupports
        public ActionResult Index()
        {
            return View(db.MaterialSupports.ToList());
        }

        // GET: MaterialSupports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialSupport materialSupport = db.MaterialSupports.Find(id);
            if (materialSupport == null)
            {
                return HttpNotFound();
            }
            return View(materialSupport);
        }

        // GET: MaterialSupports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialSupports/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ChairId")] MaterialSupport materialSupport)
        {
            if (ModelState.IsValid)
            {
                db.MaterialSupports.Add(materialSupport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialSupport);
        }

        // GET: MaterialSupports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialSupport materialSupport = db.MaterialSupports.Find(id);
            if (materialSupport == null)
            {
                return HttpNotFound();
            }
            return View(materialSupport);
        }

        // POST: MaterialSupports/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ChairId")] MaterialSupport materialSupport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialSupport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialSupport);
        }

        // GET: MaterialSupports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialSupport materialSupport = db.MaterialSupports.Find(id);
            if (materialSupport == null)
            {
                return HttpNotFound();
            }
            return View(materialSupport);
        }

        // POST: MaterialSupports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialSupport materialSupport = db.MaterialSupports.Find(id);
            db.MaterialSupports.Remove(materialSupport);
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
