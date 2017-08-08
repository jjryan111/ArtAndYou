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
    public class ArtInfoesController : Controller
    {
        private ArtInfoEntities db = new ArtInfoEntities();

        // GET: ArtInfoes
        public ActionResult Index()
        {
            return View(db.ArtInfoes.ToList());
        }

        // GET: ArtInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtInfo artInfo = db.ArtInfoes.Find(id);
            if (artInfo == null)
            {
                return HttpNotFound();
            }
            return View(artInfo);
        }

        // GET: ArtInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Artist,Year,Genre,Medium,ImageFile")] ArtInfo artInfo)
        {
            if (ModelState.IsValid)
            {
                db.ArtInfoes.Add(artInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artInfo);
        }

        // GET: ArtInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtInfo artInfo = db.ArtInfoes.Find(id);
            if (artInfo == null)
            {
                return HttpNotFound();
            }
            return View(artInfo);
        }

        // POST: ArtInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Artist,Year,Genre,Medium,ImageFile")] ArtInfo artInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artInfo);
        }

        // GET: ArtInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtInfo artInfo = db.ArtInfoes.Find(id);
            if (artInfo == null)
            {
                return HttpNotFound();
            }
            return View(artInfo);
        }

        // POST: ArtInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtInfo artInfo = db.ArtInfoes.Find(id);
            db.ArtInfoes.Remove(artInfo);
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
