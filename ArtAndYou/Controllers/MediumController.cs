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
            ViewBag.Name = M.firstName;
            return View(M.medium);
        }
        public ActionResult Q1Genre()
        {
           
            return View();
        }
        public ActionResult Q2Category(Medium m)
        {
            ViewBag.Genre = m.genre;
            ViewBag.Name = m.firstName;
            ViewBag.Medium = m.medium;
            return View();
        }
    }
}