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
using CaseTracker.CustomAnnotation;

namespace CaseTracker.Controllers
{
    [CustomAdminAnnotation.YourCustomAuthorize(Roles = "Admin")]
    public class DeedResultsController : BaseController
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.DeedResults.ToList());
        }

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Result,IsPayable")] DeedResult deedResult)
        {
            if (ModelState.IsValid)
            {
                db.DeedResults.Add(deedResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deedResult);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Result,IsPayable")] DeedResult deedResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deedResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deedResult);
        }

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
