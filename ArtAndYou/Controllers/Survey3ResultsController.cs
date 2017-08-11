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
    public class Survey3ResultsController : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();

        // GET: Survey3Results
        public ActionResult Index()
        {
            return View(db.Survey3Results.ToList());
        }

        // GET: Survey3Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3Results survey3Results = db.Survey3Results.Find(id);
            if (survey3Results == null)
            {
                return HttpNotFound();
            }
            return View(survey3Results);
        }

        // GET: Survey3Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey3Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Classification,ID,Century,Genre,ImageUrl")] Survey3Results survey3Results)
        {
            if (ModelState.IsValid)
            {
                db.Survey3Results.Add(survey3Results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey3Results);
        }

        // GET: Survey3Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3Results survey3Results = db.Survey3Results.Find(id);
            if (survey3Results == null)
            {
                return HttpNotFound();
            }
            return View(survey3Results);
        }

        // POST: Survey3Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Classification,ID,Century,Genre,ImageUrl")] Survey3Results survey3Results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey3Results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey3Results);
        }

        // GET: Survey3Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3Results survey3Results = db.Survey3Results.Find(id);
            if (survey3Results == null)
            {
                return HttpNotFound();
            }
            return View(survey3Results);
        }

        // POST: Survey3Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey3Results survey3Results = db.Survey3Results.Find(id);
            db.Survey3Results.Remove(survey3Results);
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
