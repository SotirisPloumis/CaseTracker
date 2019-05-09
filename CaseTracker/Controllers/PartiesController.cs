using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App_LocalResources;
using CaseTracker.Models;
using CaseTracker.Repository;
using Microsoft.AspNet.Identity;

namespace CaseTracker.Controllers
{
	[Authorize]
    public class PartiesController : BaseController
	{
        private ApplicationDbContext db;
		private PartyRepository PartyRepository;

		public PartiesController()
		{
			db = new ApplicationDbContext();
			PartyRepository = new PartyRepository();
		}

        public ActionResult Index()
        {
			string userID = User.Identity.GetUserId();
			bool isAdmin = User.IsInRole("Admin");

			var parties = db.Parties
							.Include(p => p.CaseRole)
							.Where(p => p.UserId == userID || isAdmin)
							.ToList();

            return View(parties);
        }

        public ActionResult Details(int? id)
        {
			string userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null || party.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        public ActionResult Create()
        {
			Party p = new Party();
			p.TranslateRoles();
			return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,FathersName,CaseRoleId,Street,City,Municipality,PostCode,WorkPhone,HomePhone,MobilePhone,FAX,AFM,IDCard")] Party party)
        {
			string userID = User.Identity.GetUserId();

			if (ModelState.IsValid)
            {
				PartyRepository.InsertParty(userID, 
											party.FirstName, 
											party.LastName, 
											party.FathersName, 
											party.CaseRoleId, 
											party.Street, 
											party.City, 
											party.Municipality, 
											party.PostCode, 
											party.WorkPhone, 
											party.HomePhone, 
											party.MobilePhone, 
											party.FAX, 
											party.AFM, 
											party.IDCard);
                return RedirectToAction("Index");
            }

			party.TranslateRoles();
            return View(party);
        }

        public ActionResult Edit(int? id)
        {
			string userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null || party.UserId != userID)
            {
                return HttpNotFound();
            }
			party.TranslateRoles();
            return View(party);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,FathersName,CaseRoleId," +
												 "Street,City,Municipality,PostCode,WorkPhone,HomePhone," +
												 "MobilePhone,FAX,AFM,IDCard")] Party party)
        {
			string userID = User.Identity.GetUserId();

			Party partyToEdit = db.Parties.Find(party.Id);

			if (ModelState.IsValid && partyToEdit.UserId == userID)
            {
				partyToEdit.FirstName = party.FirstName;
				partyToEdit.LastName = party.LastName;
				partyToEdit.FathersName = party.FathersName;
				partyToEdit.CaseRoleId = party.CaseRoleId;
				partyToEdit.Street = party.Street;
				partyToEdit.City = party.City;
				partyToEdit.Municipality = party.Municipality;
				partyToEdit.PostCode = party.PostCode;
				partyToEdit.WorkPhone = party.WorkPhone;
				partyToEdit.HomePhone = party.HomePhone;
				partyToEdit.MobilePhone = party.MobilePhone;
				partyToEdit.FAX = party.FAX;
				partyToEdit.AFM = party.AFM;
				partyToEdit.IDCard = party.IDCard;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
			party.TranslateRoles();
			return View(party);
        }

		public ActionResult Delete(int? id)
        {
			string userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Party party = db.Parties.Find(id);
            if (party == null || party.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			string userID = User.Identity.GetUserId();

			Party party = db.Parties.Find(id);
			if (party == null || party.UserId != userID)
			{
				return HttpNotFound();
			}
            db.Parties.Remove(party);
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
