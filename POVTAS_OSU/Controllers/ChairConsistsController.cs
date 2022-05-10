﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POVTAS_OSU.Models;
using System.Text.RegularExpressions;

namespace POVTAS_OSU.Controllers
{
    
    public class ChairConsistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChairConsists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChairConsist chairConsist = db.ChairConsists.Include(c => c.AcademicDegree)
                                                        .Include(c => c.AcademicTitle)
                                                        .Include(c => c.Activity)
                                                        .Include(c => c.Position)
                                                        .Include(c => c.Disciplines)
                                                        .Single(x => x.Id == id);
            if (chairConsist == null)
            {
                return HttpNotFound();
            }
            return View(chairConsist);
        }

        [Authorize(Roles = "admin")]

        // GET: ChairConsists
        public ActionResult Index()
        {
            var chairConsists = db.ChairConsists.Include(c => c.AcademicDegree).Include(c => c.AcademicTitle).Include(c => c.Activity).Include(c => c.Position);
            return View(chairConsists.ToList());
        }

       

        // GET: ChairConsists/Create
        public ActionResult Create()
        {
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title");
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title");
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title");
            //ViewBag.DisciplineId = new SelectList(db.Positions, "Id", "Title");
            ViewBag.DiscilineList = db.Disciplines.ToList();
            return View();
        }

        // POST: ChairConsists/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,ActivityId,AcademicTitleId,AcademicDegreeId,PositionId,ChairId")]HttpPostedFileBase Photo, ChairConsist chairConsist, ICollection<int> sel)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string filename = Photo.FileName;
                    Photo.SaveAs(Server.MapPath("/Images/" + filename));
                    chairConsist.Photo = "/Images/" + filename;
                }
                db.ChairConsists.Add(chairConsist);
                if (sel!=null) chairConsist.Disciplines = db.Disciplines.Where(x => sel.Contains(x.Id)).ToArray();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            //ViewBag.DisciplineId = new SelectList(db.Positions, "Id", "Title");
            ViewBag.DiscilineList = db.Disciplines.ToList();
            return View(chairConsist);
        }

        // GET: ChairConsists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChairConsist chairConsist = db.ChairConsists.Include(c => c.AcademicDegree)
                                                        .Include(c => c.AcademicTitle)
                                                        .Include(c => c.Activity)
                                                        .Include(c => c.Position)
                                                        .Include(c => c.Disciplines)
                                                        .Single(x => x.Id == id);
            if (chairConsist == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            //ViewBag.DisciplineId = new SelectList(db.Disciplines, "Id", "Title", chairConsist.Disciplines);
            ViewBag.DiscilineList = db.Disciplines.ToList();
            return View(chairConsist);
        }

        // POST: ChairConsists/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,PatronymicName,WorkExperience,TeachingExperience,Education,Details,Emails,Schedule,Training,ActivityId,AcademicTitleId,AcademicDegreeId,PositionId,ChairId")] HttpPostedFileBase Photo, ChairConsist chairConsist, string oldPhoto, ICollection<int> sel)
        {
        //    string message;
        //    string field;
        //    bool validateResult = Validate(chairConsist, out message, out field); /*&& validateResult*/
            if (ModelState.IsValid )
            {
                if (Photo != null)
                {
                    string filename = Photo.FileName;
                    Photo.SaveAs(Server.MapPath("/Images/" + filename));
                    chairConsist.Photo = "/Images/" + filename;
                }
                else chairConsist.Photo = oldPhoto;

                db.Entry(chairConsist).State = EntityState.Modified;
                db.SaveChanges();

                var cc = db.ChairConsists.Include(c => c.Disciplines).Single(x => x.Id == chairConsist.Id);
                if (sel != null)
                    cc.Disciplines = db.Disciplines.Where(x => sel.Contains(x.Id)).ToList();
                else
                    cc.Disciplines = new List<Discipline>();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //else if (!validateResult)
            //{
            //    ModelState.AddModelError(field, message);
            //    chairConsist.Photo = oldPhoto;
            //}
           
            
            ViewBag.AcademicDegreeId = new SelectList(db.AcademicDegrees, "Id", "Title", chairConsist.AcademicDegreeId);
            ViewBag.AcademicTitleId = new SelectList(db.AcademicTitles, "Id", "Title", chairConsist.AcademicTitleId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "Title", chairConsist.ActivityId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Title", chairConsist.PositionId);
            //ViewBag.DisciplineId = new SelectList(db.Disciplines, "Id", "Title");
            ViewBag.DiscilineList = db.Disciplines.ToList();
            return View(chairConsist);
        }

        //private bool Validate (ChairConsist chairConsist, out string errorMessage, out string errorField)
        //{
        //    errorMessage = "";
        //    errorField = "";

        //    if(!Regex.Match(chairConsist.Name, @"^[А-Я][а-яА-я\s]*$").Success)
        //    {
        //        errorMessage = "Имя введено неверно";
        //        errorField = "Name";
        //        return false;
        //    }

        //    if (!Regex.Match(chairConsist.Surname, @"^[А-Я][а-яА-я\s]*$").Success)
        //    {
        //        errorMessage = "Фамилия введена неверно";
        //        errorField = "Surname";
        //        return false;
        //    }

        //    if (!Regex.Match(chairConsist.PatronymicName, @"^[А-Я][а-яА-я\s]*$").Success)
        //    {
        //        errorMessage = "Отчество введено неверно";
        //        errorField = "PatronymicName";
        //        return false;
        //    }

        //    if (!Regex.Match(chairConsist.TeachingExperience, @"^[0-9]*$").Success)
        //    {
        //        errorMessage = "Стаж введен неверно и может содержать только цифры";
        //        errorField = "TeachingExperience";
        //        return false;
        //    }

        //    if (!Regex.Match(chairConsist.WorkExperience, @"^[0-9]*$").Success)
        //    {
        //        errorMessage = "Стаж введен неверно и может содержать только цифры";
        //        errorField = "WorkExperience";
        //        return false;
        //    }
        //    return true;
        //}

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
