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
    public class Survey1ResultsController : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();

        // GET: Survey1Results
        public ActionResult Index()
        {
            return View(db.Survey1Results.ToList());
        }

        // GET: Survey1Results/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1Results survey1Results = db.Survey1Results.Find(id);
            if (survey1Results == null)
            {
                return HttpNotFound();
            }
            return View(survey1Results);
        }

        // GET: Survey1Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey1Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medium,Classification,ImageUrl,Name,ID")] Survey1Results survey1Results)
        {
            if (ModelState.IsValid)
            {
                db.Survey1Results.Add(survey1Results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey1Results);
        }

        // GET: Survey1Results/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1Results survey1Results = db.Survey1Results.Find(id);
            if (survey1Results == null)
            {
                return HttpNotFound();
            }
            return View(survey1Results);
        }

        // POST: Survey1Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medium,Classification,ImageUrl,Name,ID")] Survey1Results survey1Results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey1Results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey1Results);
        }

        // GET: Survey1Results/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey1Results survey1Results = db.Survey1Results.Find(id);
            if (survey1Results == null)
            {
                return HttpNotFound();
            }
            return View(survey1Results);
        }

        // POST: Survey1Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Survey1Results survey1Results = db.Survey1Results.Find(id);
            db.Survey1Results.Remove(survey1Results);
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
