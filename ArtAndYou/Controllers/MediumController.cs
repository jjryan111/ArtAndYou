using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;
using ArtAndYou.Controllers;
using System.Data.Entity;
using System.Data.Sql;
using System.Web.Mvc;
using System.Net;

namespace ArtAndYou.Controllers
{
    public class MediumController : Controller
    {
        public string name;
        public string medium;
        // GET: Medium
        public ActionResult Index(Medium M)
        {
            List <Survey1> thing = M.Details("5");
            ViewBag.thing2 = thing[0].ToString();
            ViewBag.Thing3 = "thing";
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
        public ActionResult Q2Category(string name)
        {
            ViewBag.Thing = "Hello World";
            ViewBag.Name = this.name;
            return View();
        }
        public ActionResult Edit([Bind(Include = "ID,Name,Classification,Century,Culture")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(userInfo).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }
    }
}