using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseTracker.Models;
using CaseTracker.Repository;

namespace CaseTracker.Controllers
{
    public class AttorneyController : BaseController
	{
        private ApplicationDbContext db;

		public AttorneyController()
		{
			db = new ApplicationDbContext();
		}

        public ActionResult Index()
        {
            return View(db.Attorneys.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        // GET: Attorneys/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                db.Attorneys.Add(attorney);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attorney);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attorney).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attorney);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attorney attorney = db.Attorneys.Find(id);
            db.Attorneys.Remove(attorney);
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
