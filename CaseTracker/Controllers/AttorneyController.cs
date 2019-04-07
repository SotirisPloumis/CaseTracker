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
    public class AttorneyController : Controller
    {
        private ApplicationDbContext db;

		public AttorneyController()
		{
			db = new ApplicationDbContext();
		}

        // GET: Attorneys
        public ActionResult Index()
        {
            return View(db.Attorneys.ToList());
        }

        // GET: Attorneys/Details/5
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

        // POST: Attorneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Attorneys/Edit/5
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

        // POST: Attorneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Attorneys/Delete/5
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

        // POST: Attorneys/Delete/5
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
