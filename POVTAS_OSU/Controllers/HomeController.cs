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

        public ActionResult Contact()
        {
            return View(db.Contacts);
        }

        public ActionResult Disciplines(string Id)
        {
            
            var disciplines = db.Disciplines.Include(d => d.EducationField).OrderBy(x => x.Title);
            ViewBag.EducationFields = db.EducationFields.ToList();
            if (Id != null)
            {
                ViewBag.Id = Id;
                return View(disciplines.Where(x => x.EducationFieldId.ToString() == Id).ToList());
            }
            else
            {
                ViewBag.Id = 0;
                return View(new List<Discipline>());
            }
           
        }

        public ActionResult Reports()
        {
            return View(db.Posts);
        }

        public ActionResult Teachers()
        {
            var chairConsists = db.ChairConsists.Include(c => c.AcademicDegree).Include(c => c.AcademicTitle).Include(c => c.Activity).Include(c => c.Position);
           
            return View(chairConsists.ToList());
        }



        public ActionResult ResearchWorkAndActivities()
        {
            return View();
        }

        public ActionResult StudentsAndAlumnus(string Id)
        {
            var documents = db.Documents.Include(d => d.DocumentType).OrderBy(x => x.DocumentType.Title);
            ViewBag.DocumentTypes = db.DocumentType.ToList();
            if (Id != null)
            {
                return View(documents.Where(x => x.DocumentTypeId.ToString() == Id).ToList());
            }
            else
            {
                return View(new List<Document>());
            }
        }

        public ActionResult Schoolchildren()
        {
            return View();
        }

        public ActionResult EducationalPrograms()
        {
            return View(db.EducationFields);
        }

        public ActionResult Support()
        {
            return View();
        }
    }
}