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
    public class CentQueriesController : Controller
    {
        private ArtInfoEntities4 db = new ArtInfoEntities4();

        // GET: CentQueries
        public ActionResult Index()
        {
            return View(db.CentQueries.ToList());
        }

        // GET: CentQueries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentQuery centQuery = db.CentQueries.Find(id);
            if (centQuery == null)
            {
                return HttpNotFound();
            }
            return View(centQuery);
        }

        // GET: CentQueries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentQueries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Artist,Genre,Medium,ImageFile,ImageUrl,Title,Year")] CentQuery centQuery)
        {
            if (ModelState.IsValid)
            {
                db.CentQueries.Add(centQuery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centQuery);
        }

        // GET: CentQueries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentQuery centQuery = db.CentQueries.Find(id);
            if (centQuery == null)
            {
                return HttpNotFound();
            }
            return View(centQuery);
        }

        // POST: CentQueries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Artist,Genre,Medium,ImageFile,ImageUrl,Title,Year")] CentQuery centQuery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centQuery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centQuery);
        }

        // GET: CentQueries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentQuery centQuery = db.CentQueries.Find(id);
            if (centQuery == null)
            {
                return HttpNotFound();
            }
            return View(centQuery);
        }

        // POST: CentQueries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentQuery centQuery = db.CentQueries.Find(id);
            db.CentQueries.Remove(centQuery);
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
