﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseTracker.CustomAnnotations;
using CaseTracker.Models;
using CaseTracker.Repository;

namespace CaseTracker.Controllers
{
	[NotAllowed(Roles = "Admin")]
	public class ZonesController : BaseController
	{
        private ApplicationDbContext db;

		public ZonesController()
		{
			db = new ApplicationDbContext();
		}

        public ActionResult Index(int? page)
        {
			int pageSize = 20;
			var Zones = db.Zones;
			int count = Zones.Count();
			int numOfPages = count / pageSize + (count % pageSize > 0 ? 1 : 0);

			page = page ?? 1;
			if (page < 1)
			{
				page = 1;
			}
			if (page > numOfPages)
			{
				page = numOfPages;
			}

			int startIndex = ((int)page - 1) * pageSize;

			var ZoneList = Zones
									.OrderBy(t => t.Id)
									.Skip(startIndex)
									.Take(pageSize)
									.ToList();

			ViewBag.NumOfPages = numOfPages;
			ViewBag.CurrentPage = page;

			return View(ZoneList);
		}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CostFull,CostClean")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Zones.Add(zone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zone);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CostFull,CostClean")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zone);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zone zone = db.Zones.Find(id);
            db.Zones.Remove(zone);
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
