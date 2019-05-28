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
	public class DocumentTypesController : BaseController
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
			int pageSize = 20;
			var DocumentTypes = db.DocumentTypes;
			int count = DocumentTypes.Count();
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

			var documentTypeList = DocumentTypes
									.OrderBy(t => t.Id)
									.Skip(startIndex)
									.Take(pageSize)
									.ToList();

			ViewBag.NumOfPages = numOfPages;
			ViewBag.CurrentPage = page;

			return View(documentTypeList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.DocumentTypes.Add(documentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentType);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentType);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentType documentType = db.DocumentTypes.Find(id);
            if (documentType == null)
            {
                return HttpNotFound();
            }
            return View(documentType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentType documentType = db.DocumentTypes.Find(id);
            db.DocumentTypes.Remove(documentType);
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
