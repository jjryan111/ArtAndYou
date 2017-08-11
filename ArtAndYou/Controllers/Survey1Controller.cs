using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtAndYou.Models;

namespace ArtAndYou.Controllers
{
    public class Survey1Controller : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();
        private ArtInfoEntities1 db2 = new ArtInfoEntities1();
        // GET: Survey1
        public ActionResult Index()
        {
            return View(db.Survey1.ToList());
        }

        // GET: Survey1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1 survey1 = db.Survey1.Find(id);
            if (survey1 == null)
            {
                return HttpNotFound();
            }
            return View(survey1);
        }

        // GET: Survey1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medium,ImageUrl")] Survey1 survey1)
        {
            if (ModelState.IsValid)
            {
                db.Survey1.Add(survey1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey1);
        }

        // GET: Survey1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1 survey1 = db.Survey1.Find(id);
            if (survey1 == null)
            {
                return HttpNotFound();
            }
            return View(survey1);
        }
        public ActionResult ClassificationEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1 survey1 = db.Survey1.Find(id);
            if (survey1 == null)
            {
                return HttpNotFound();
            }
            return View(survey1);
        }


        // POST: Survey1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medium,ImageUrl")] Survey1 survey1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClassificationEdit([Bind(Include = "ID,classification")] Survey1 survey1)
        {
            if (ModelState.IsValid)
            {
                db2.Entry(survey1).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("Index","Survey2");
            }
            return View(survey1);
        }


        // GET: Survey1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1 survey1 = db.Survey1.Find(id);
            if (survey1 == null)
            {
                return HttpNotFound();
            }
            return View(survey1);
        }

        // POST: Survey1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Survey1 survey1 = db.Survey1.Find(id);
            db.Survey1.Remove(survey1);
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
