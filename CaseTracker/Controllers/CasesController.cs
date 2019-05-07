using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseTracker.Models;
using CaseTracker.ViewModels;
using CaseTracker.Repository;
using System.Diagnostics;

namespace CaseTracker.Controllers
{
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cases = db.Cases
						.Include(c => c.Attorney)
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.Include(c => c.Zone)
						.OrderByDescending(c => c.Id);
            return View(cases.ToList());
        }

		public ActionResult Book()
		{
			var cases = db.Cases
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.OrderByDescending(c => c.Id);

			return View(cases.ToList());
		}

		public ActionResult Pinakio()
		{
			var cases = db.Cases
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.Include(c => c.Zone)
						.OrderByDescending(c => c.Id);

			return View(cases.ToList());
		}

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

        public ActionResult Create()
        {
			CreateCaseViewModel vm = new CreateCaseViewModel();
			vm.PrepareLists();

            return View(vm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateCaseViewModel vm)
		{

			if (db.Cases.Any(x => x.Aa == vm.Aa) || !ModelState.IsValid)
			{
				vm.PrepareLists();
				return View(vm);
			}

			Case newCase = new Case();
            Party newParty = new Party();
			newCase.Update(vm);            

			db.Cases.Add(newCase);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
				Debug.Print("error");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case caseToChange = db.Cases.Find(id);
            if (caseToChange == null)
            {
                return HttpNotFound();
            }
			EditCaseViewModel oldCase = new EditCaseViewModel();

			oldCase.Update(caseToChange);
			oldCase.PrepareLists();

			return View(oldCase);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EditCaseViewModel vm)
		{
			Case c = db.Cases.Find(vm.Id);

			bool badAa = db.Cases.Any(x => x.Aa == vm.Aa && x.Id != vm.Id);

			if (!ModelState.IsValid || c == null || badAa)
			{
				vm.PrepareLists();

				return View(vm);
			}

			c.Update(vm);

			db.SaveChanges();
			return RedirectToAction("Index");

		}

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

		public JsonResult UniqueAACreate(string aa)
		{
			Debug.Print(aa);
			return Json(!db.Cases.Any(x => x.Aa == aa), JsonRequestBehavior.AllowGet);
		}

		public JsonResult UniqueAAEdit(string aa, int Id)
		{
			Debug.Print(aa);
			Debug.Print(Id.ToString());
			return Json(!db.Cases.Any(x => x.Aa == aa && x.Id != Id), JsonRequestBehavior.AllowGet);
		}
	}
}
