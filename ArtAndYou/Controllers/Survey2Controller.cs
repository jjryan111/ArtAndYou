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
    public class Survey2Controller : Controller
    {
        private ArtInfoEntities2 db = new ArtInfoEntities2();

        // GET: Survey2
        public ActionResult Index()
        {
            return View(db.Survey2.ToList());
        }

        // GET: Survey2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2 survey2 = db.Survey2.Find(id);
            if (survey2 == null)
            {
                return HttpNotFound();
            }
            return View(survey2);
        }

        // GET: Survey2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Classification,ID,Year,ImageUrl")] Survey2 survey2)
        {
            if (ModelState.IsValid)
            {
                db.Survey2.Add(survey2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey2);
        }

        // GET: Survey2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2 survey2 = db.Survey2.Find(id);
            if (survey2 == null)
            {
                return HttpNotFound();
            }
            return View(survey2);
        }

        // POST: Survey2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Classification,ID,Year,ImageUrl")] Survey2 survey2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey2);
        }

        // GET: Survey2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey2 survey2 = db.Survey2.Find(id);
            if (survey2 == null)
            {
                return HttpNotFound();
            }
            return View(survey2);
        }

        // POST: Survey2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey2 survey2 = db.Survey2.Find(id);
            db.Survey2.Remove(survey2);
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
