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
    public class Survey2ResultsController : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();

        // GET: Survey2Results
        public ActionResult Index()
        {
            return View(db.Survey2Results.ToList());
        }

        // GET: Survey2Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2Results survey2Results = db.Survey2Results.Find(id);
            if (survey2Results == null)
            {
                return HttpNotFound();
            }
            return View(survey2Results);
        }

        // GET: Survey2Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey2Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Classification,ID,Year,Century,ImageUrl")] Survey2Results survey2Results)
        {
            if (ModelState.IsValid)
            {
                db.Survey2Results.Add(survey2Results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey2Results);
        }

        // GET: Survey2Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2Results survey2Results = db.Survey2Results.Find(id);
            if (survey2Results == null)
            {
                return HttpNotFound();
            }
            return View(survey2Results);
        }

        // POST: Survey2Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Classification,ID,Year,Century,ImageUrl")] Survey2Results survey2Results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey2Results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey2Results);
        }

        // GET: Survey2Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2Results survey2Results = db.Survey2Results.Find(id);
            if (survey2Results == null)
            {
                return HttpNotFound();
            }
            return View(survey2Results);
        }

        // POST: Survey2Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey2Results survey2Results = db.Survey2Results.Find(id);
            db.Survey2Results.Remove(survey2Results);
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
