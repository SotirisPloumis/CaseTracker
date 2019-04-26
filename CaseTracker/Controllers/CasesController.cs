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
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases
						.Include(c => c.Attorney)
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
			

            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            ViewBag.AttorneyId = new SelectList(db.Attorneys, "Id", "FullName");
            ViewBag.CourtId = new SelectList(db.Courts, "Id", "Name");
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description");

			var Prosecutors = db.Parties.Where(c => c.CaseRole.Title == "Prosecution");
			var Defenders = db.Parties.Where(c => c.CaseRole.Title == "Defense");
			var Recipients = db.Parties.Where(c => c.CaseRole.Title == "Recipient");

			ViewBag.ProsecutionId = new SelectList(Prosecutors, "Id", "Fullname");
			ViewBag.DefenseId = new SelectList(Defenders, "Id", "Fullname");
			ViewBag.RecipientId = new SelectList(Recipients, "Id", "Fullname");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aa,DocumentTypeId,CourtId,AttorneyId" +
			                                       ",DateOfAssignment,DateOfSubmission,DateOfEnd" +
												   ",Notes,ProsecutionId,DefenseId,RecipientId")] Case @case)
        {
			
            if (!db.Cases.Any(x => x.Aa == @case.Aa) && ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttorneyId = new SelectList(db.Attorneys, "Id", "FirstName", @case.AttorneyId);
            ViewBag.CourtId = new SelectList(db.Courts, "Id", "Name", @case.CourtId);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", @case.DocumentTypeId);
			var Prosecutors = db.Parties.Where(c => c.CaseRole.Title == "Prosecution");
			var Defenders = db.Parties.Where(c => c.CaseRole.Title == "Defense");
			var Recipients = db.Parties.Where(c => c.CaseRole.Title == "Recipient");
			ViewBag.ProsecutionId = new SelectList(Prosecutors, "Id", "Fullname",@case.ProsecutionId);
			ViewBag.DefenseId = new SelectList(Defenders, "Id", "Fullname",@case.DefenseId);
			ViewBag.RecipientId = new SelectList(Recipients, "Id", "Fullname",@case.RecipientId);
			return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttorneyId = new SelectList(db.Attorneys, "Id", "FirstName", @case.AttorneyId);
            ViewBag.CourtId = new SelectList(db.Courts, "Id", "Name", @case.CourtId);
			ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", @case.DocumentTypeId);
			var Prosecutors = db.Parties.Where(c => c.CaseRole.Title == "Prosecution");
			var Defenders = db.Parties.Where(c => c.CaseRole.Title == "Defense");
			var Recipients = db.Parties.Where(c => c.CaseRole.Title == "Recipient");
			ViewBag.ProsecutionId = new SelectList(Prosecutors, "Id", "Fullname", @case.ProsecutionId);
			ViewBag.DefenseId = new SelectList(Defenders, "Id", "Fullname", @case.DefenseId);
			ViewBag.RecipientId = new SelectList(Recipients, "Id", "Fullname", @case.RecipientId);
			return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aa,DocumentTypeId,CourtId,AttorneyId,DateOfAssignment," +
													"DateOfSubmission,DateOfEnd," +
													"Notes,ProsecutionId,DefenseId,RecipientId")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttorneyId = new SelectList(db.Attorneys, "Id", "FirstName", @case.AttorneyId);
            ViewBag.CourtId = new SelectList(db.Courts, "Id", "Name", @case.CourtId);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", @case.DocumentTypeId);
			var Prosecutors = db.Parties.Where(c => c.CaseRole.Title == "Prosecution");
			var Defenders = db.Parties.Where(c => c.CaseRole.Title == "Defense");
			var Recipients = db.Parties.Where(c => c.CaseRole.Title == "Recipient");
			ViewBag.ProsecutionId = new SelectList(Prosecutors, "Id", "Fullname", @case.ProsecutionId);
			ViewBag.DefenseId = new SelectList(Defenders, "Id", "Fullname", @case.DefenseId);
			ViewBag.RecipientId = new SelectList(Recipients, "Id", "Fullname", @case.RecipientId);
			return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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

		public JsonResult UniqueAA(string aa)
		{
			return Json(!db.Cases.Any(x => x.Aa == aa), JsonRequestBehavior.AllowGet);
		}
	}
}
