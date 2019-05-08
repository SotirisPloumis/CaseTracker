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
using Microsoft.AspNet.Identity;

namespace CaseTracker.Controllers
{
	[Authorize]
    public class CasesController : BaseController
	{
        private ApplicationDbContext db;
		private string userID;
		private CaseRepository CaseRepository;
		private AttorneyRepository AttorneyRepository;
		private CourtRepository CourtRepository;
		private PartyRepository PartyRepository;

		public CasesController()
		{
			db = new ApplicationDbContext();
			CaseRepository = new CaseRepository();
			AttorneyRepository = new AttorneyRepository();
			CourtRepository = new CourtRepository();
			PartyRepository = new PartyRepository();
		}

		public ActionResult Index()
        {
			userID = User.Identity.GetUserId();

			var cases = CaseRepository.GetCases(userID);

            return View(cases);
        }

		public ActionResult Book()
		{
			userID = User.Identity.GetUserId();

			var cases = CaseRepository.GetBookCases(userID);

			return View(cases);
		}

		public ActionResult Pinakio()
		{
			userID = User.Identity.GetUserId();

			var cases = CaseRepository.GetPinakioCases(userID);

			return View(cases);
		}

		public ActionResult Details(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
			

            if (@case == null || @case.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        public ActionResult Create()
        {
			userID = User.Identity.GetUserId();

			CreateCaseViewModel vm = new CreateCaseViewModel();
			vm.PrepareLists(userID);

            return View(vm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateCaseViewModel vm)
		{
			userID = User.Identity.GetUserId();

			if (db.Cases.Any(x => x.Aa == vm.Aa && x.UserId == userID) || !ModelState.IsValid)
			{
				vm.PrepareLists(userID);
				return View(vm);
			}

			if (vm.newAttorney)
			{
				vm.AttorneyId = AttorneyRepository.InsertAttorney(userID, vm);
			}

			if (vm.newCourt)
			{
				vm.CourtId = CourtRepository.InsertCourt(userID, vm);
			}

			if (vm.newProsecution)
			{
				vm.ProsecutionId = PartyRepository.InsertPartyProsecution(userID, vm);
			}

			if (vm.newDefense)
			{
				vm.DefenseId = PartyRepository.InsertPartyDefense(userID, vm);
			}

			if (vm.newRecipient)
			{
				vm.RecipientId = PartyRepository.InsertPartyRecipient(userID, vm);
			}

			CaseRepository.InsertCaseFromViewModel(userID,vm);

			return RedirectToAction("Index");
		}

		public ActionResult Edit(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
				Debug.Print("error");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case caseToChange = db.Cases.Find(id);
            if (caseToChange == null || caseToChange.UserId != userID)
            {
                return HttpNotFound();
            }
			EditCaseViewModel oldCase = new EditCaseViewModel();

			oldCase.Update(caseToChange);
			oldCase.PrepareLists(userID);

			return View(oldCase);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EditCaseViewModel vm)
		{
			userID = User.Identity.GetUserId();

			Case c = db.Cases.Find(vm.Id);

			bool badAa = db.Cases.Any(x => x.Aa == vm.Aa && x.Id != vm.Id && x.UserId == userID);

			if (!ModelState.IsValid || c == null || c.UserId != userID || badAa)
			{
				vm.PrepareLists(userID);

				return View(vm);
			}

			c.Update(vm);

			db.SaveChanges();
			return RedirectToAction("Index");

		}

		public ActionResult Delete(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null || @case.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			userID = User.Identity.GetUserId();

			Case @case = db.Cases.Find(id);
			if (@case == null || @case.UserId != userID)
			{
				return HttpNotFound();
			}
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
			userID = User.Identity.GetUserId();
			//Debug.Print(aa);
			return Json(!db.Cases.Any(x => x.Aa == aa && x.UserId == userID), JsonRequestBehavior.AllowGet);
		}

		public JsonResult UniqueAAEdit(string aa, int Id)
		{
			userID = User.Identity.GetUserId();
			//Debug.Print(aa);
			//Debug.Print(Id.ToString());
			return Json(!db.Cases.Any(x => x.Aa == aa && x.Id != Id && x.UserId == userID), JsonRequestBehavior.AllowGet);
		}
	}
}
