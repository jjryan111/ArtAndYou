﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;
using ArtAndYou.Controllers;
using System.Data.Entity;
using System.Data.Sql;
using System.Net;

namespace ArtAndYou.Controllers

{
    public class MediumController : Controller
    {
        private ArtInfoEntities1 db = new ArtInfoEntities1();
        public string name;
        public string medium;
        // GET: Medium
        public ActionResult Index()
        {
            //List <Survey1> thing = M.Details("5");
            //ViewBag.thing2 = thing[1].ToString();
            //ViewBag.Thing3 = "thing";
            return View();
        }
        public ActionResult Medium()
        {
            return View();
        }
        //public ActionResult Choice(Medium M)
        //{
        //    this.name = M.firstName;
        //    this.medium = M.medium;
        //    ViewBag.Name = name;
        //    return View(M.medium);
        //}
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ClassEdit([Bind(Include = "ID,Classification")] UserInfo userInfo,Survey1 clsurv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                clsurv.Medium = userInfo.Classification;
                //userInfo = db.UserInfoes.Find(ID);
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }
    }
}