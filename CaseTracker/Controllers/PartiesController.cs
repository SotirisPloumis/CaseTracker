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

		public PartiesController()
		{
			db = new ApplicationDbContext();
		}

        public ActionResult Index()
        {
			string userID = User.Identity.GetUserId();

            var parties = db.Parties
							.Include(p => p.CaseRole)
							.Where(p => p.UserId == userID)
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
				party.UserId = userID;
                db.Parties.Add(party);
                db.SaveChanges();
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,FathersName,CaseRoleId,Street,City,Municipality,PostCode,WorkPhone,HomePhone,MobilePhone,FAX,AFM,IDCard")] Party party)
        {
			string userID = User.Identity.GetUserId();

			if (ModelState.IsValid && party.UserId == userID)
            {
                db.Entry(party).State = EntityState.Modified;
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
