﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;

namespace ArtAndYou.Controllers
{
    public class HomeController : Controller
    {
        int christopher = 0;
        int thing = 0;
        int Diane = 0;
        int THingII = 0;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Medium()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Choice(Medium r)
        {
            return View(r.medium);
        }
    }
}