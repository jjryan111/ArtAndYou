using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;

namespace ArtAndYou.Controllers
{
    public class MediumController : Controller
    {
        public string name;
        public string medium;
        // GET: Medium
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Medium()
        {
            return View();
        }
        public ActionResult Choice(Medium M)
        {
            this.name = M.firstName;
            this.medium = M.medium;
            ViewBag.Name = name;
            return View(M.medium);
        }
        public ActionResult Q1Genre()
        {
           
            return View();
        }
        public ActionResult Q2Category(Medium M)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}