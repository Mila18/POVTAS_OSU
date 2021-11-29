using POVTAS_OSU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace POVTAS_OSU.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Chair);
            return View(contacts.ToList());
        }

        public ActionResult Posts()
        {
            return View(db.Posts);
        }

        public ActionResult Disciplines(string Id)
        {
            
            var disciplines = db.Disciplines.Include(d => d.EducationField).OrderBy(x => x.Title);
            ViewBag.EducationFields = db.EducationFields.ToList();
            if (Id != null)
            {
                return View(disciplines.Where(x => x.EducationFieldId.ToString() == Id).ToList());
            }
            else
            {
                return View(new List<Discipline>());
            }
           
        }

        

        public ActionResult Teachers(/*int? id*/)
        {
            var chairConsists = db.ChairConsists.Include(c => c.AcademicDegree).Include(c => c.AcademicTitle).Include(c => c.Activity).Include(c => c.Position);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ChairConsist chairConsist = db.ChairConsists.Include(c => c.AcademicDegree)
            //                                            .Include(c => c.AcademicTitle)
            //                                            .Include(c => c.Activity)
            //                                            .Include(c => c.Position)
            //                                            .Include(c => c.Disciplines)
            //                                            .Single(x => x.Id == id);
            //if (chairConsist == null)
            //{
            //    return HttpNotFound();
            //}
            
            //return View(chairConsist);
            return View(chairConsists.ToList());
        }



        public ActionResult ResearchWorkAndActivities()
        {
            return View();
        }

        public ActionResult StudentsAndAlumnus()
        {
            return View(db.Documents);
        }

        public ActionResult Schoolchildren()
        {
            return View();
        }

        public ActionResult EducationalPrograms()
        {
            return View(db.EducationFields);
        }

    }
}