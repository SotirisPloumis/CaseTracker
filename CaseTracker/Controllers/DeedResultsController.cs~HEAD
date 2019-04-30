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
    public class DeedResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeedResults
        public ActionResult Index()
        {
            return View(db.DeedResults.ToList());
        }

        // GET: DeedResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeedResult deedResult = db.DeedResults.Find(id);
            if (deedResult == null)
            {
                return HttpNotFound();
            }
            return View(deedResult);
        }

        // GET: DeedResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeedResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Result")] DeedResult deedResult)
        {
            if (ModelState.IsValid)
            {
                db.DeedResults.Add(deedResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deedResult);
        }

        // GET: DeedResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeedResult deedResult = db.DeedResults.Find(id);
            if (deedResult == null)
            {
                return HttpNotFound();
            }
            return View(deedResult);
        }

        // POST: DeedResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Result")] DeedResult deedResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deedResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deedResult);
        }

        // GET: DeedResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeedResult deedResult = db.DeedResults.Find(id);
            if (deedResult == null)
            {
                return HttpNotFound();
            }
            return View(deedResult);
        }

        // POST: DeedResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeedResult deedResult = db.DeedResults.Find(id);
            db.DeedResults.Remove(deedResult);
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
