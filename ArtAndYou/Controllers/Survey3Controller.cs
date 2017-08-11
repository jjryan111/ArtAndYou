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
    public class Survey3Controller : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();

        // GET: Survey3
        public ActionResult Index()
        {
            return View(db.Survey3.ToList());
        }

        // GET: Survey3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3 survey3 = db.Survey3.Find(id);
            if (survey3 == null)
            {
                return HttpNotFound();
            }
            return View(survey3);
        }

        // GET: Survey3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Classification,ID,Century,Genre,ImageUrl")] Survey3 survey3)
        {
            if (ModelState.IsValid)
            {
                db.Survey3.Add(survey3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey3);
        }

        // GET: Survey3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3 survey3 = db.Survey3.Find(id);
            if (survey3 == null)
            {
                return HttpNotFound();
            }
            return View(survey3);
        }

        // POST: Survey3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Classification,ID,Century,Genre,ImageUrl")] Survey3 survey3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey3);
        }

        // GET: Survey3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey3 survey3 = db.Survey3.Find(id);
            if (survey3 == null)
            {
                return HttpNotFound();
            }
            return View(survey3);
        }

        // POST: Survey3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey3 survey3 = db.Survey3.Find(id);
            db.Survey3.Remove(survey3);
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
