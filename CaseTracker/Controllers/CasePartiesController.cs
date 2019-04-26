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
    public class CasePartiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CaseParties
        public ActionResult Index()
        {
            var caseParties = db.CaseParties
								.Include(c => c.Case)
								.Include(c => c.CaseRole)
								.Include(c => c.Party);
            return View(caseParties.ToList());
        }

        // GET: CaseParties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseParties caseParties = db.CaseParties.Find(id);
            if (caseParties == null)
            {
                return HttpNotFound();
            }
            return View(caseParties);
        }

        // GET: CaseParties/Create
        public ActionResult Create()
        {
            ViewBag.CaseId = new SelectList(db.Cases, "Id", "Type");
            ViewBag.RoleId = new SelectList(db.CaseRoles, "Id", "Title");
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "FirstName");
            return View();
        }

        // POST: CaseParties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseId,PartyId,RoleId")] CaseParties caseParties)
        {
            if (ModelState.IsValid)
            {
                db.CaseParties.Add(caseParties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseId = new SelectList(db.Cases, "Id", "Type", caseParties.CaseId);
            ViewBag.RoleId = new SelectList(db.CaseRoles, "Id", "Title", caseParties.RoleId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "FirstName", caseParties.PartyId);
            return View(caseParties);
        }

        // GET: CaseParties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseParties caseParties = db.CaseParties.Find(id);
            if (caseParties == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseId = new SelectList(db.Cases, "Id", "Type", caseParties.CaseId);
            ViewBag.RoleId = new SelectList(db.CaseRoles, "Id", "Title", caseParties.RoleId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "FirstName", caseParties.PartyId);
            return View(caseParties);
        }

        // POST: CaseParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseId,PartyId,RoleId")] CaseParties caseParties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseParties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseId = new SelectList(db.Cases, "Id", "Type", caseParties.CaseId);
            ViewBag.RoleId = new SelectList(db.CaseRoles, "Id", "Title", caseParties.RoleId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "FirstName", caseParties.PartyId);
            return View(caseParties);
        }

        // GET: CaseParties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseParties caseParties = db.CaseParties.Find(id);
            if (caseParties == null)
            {
                return HttpNotFound();
            }
            return View(caseParties);
        }

        // POST: CaseParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseParties caseParties = db.CaseParties.Find(id);
            db.CaseParties.Remove(caseParties);
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
