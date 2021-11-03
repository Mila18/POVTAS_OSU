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

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View(db.Contacts);
        //}

        public ActionResult Posts()
        {
            ViewBag.Message = "Your contact page.";
            return View(db.Posts);
        }
    }
}