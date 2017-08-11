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
    public class FINALRESULTsController : Controller
    {
        private ArtInfoEntities3 db = new ArtInfoEntities3();

        // GET: FINALRESULTs
        public ActionResult Index()
        {
            return View(db.FINALRESULTS.ToList());
        }

        // GET: FINALRESULTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINALRESULT fINALRESULT = db.FINALRESULTS.Find(id);
            if (fINALRESULT == null)
            {
                return HttpNotFound();
            }
            return View(fINALRESULT);
        }

        // GET: FINALRESULTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FINALRESULTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Classification,Century,Genre")] FINALRESULT fINALRESULT)
        {
            if (ModelState.IsValid)
            {
                db.FINALRESULTS.Add(fINALRESULT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fINALRESULT);
        }

        // GET: FINALRESULTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINALRESULT fINALRESULT = db.FINALRESULTS.Find(id);
            if (fINALRESULT == null)
            {
                return HttpNotFound();
            }
            return View(fINALRESULT);
        }

        // POST: FINALRESULTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Classification,Century,Genre")] FINALRESULT fINALRESULT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fINALRESULT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fINALRESULT);
        }

        // GET: FINALRESULTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINALRESULT fINALRESULT = db.FINALRESULTS.Find(id);
            if (fINALRESULT == null)
            {
                return HttpNotFound();
            }
            return View(fINALRESULT);
        }

        // POST: FINALRESULTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FINALRESULT fINALRESULT = db.FINALRESULTS.Find(id);
            db.FINALRESULTS.Remove(fINALRESULT);
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
