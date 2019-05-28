using CaseTracker.Models;
using CaseTracker.Repository;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Diagnostics;

namespace CaseTracker.Controllers
{
	[Authorize]
	public class AttorneyController : BaseController
	{
        private ApplicationDbContext db;
		private AttorneyRepository AttorneyRepository;
		private string userID;

		public AttorneyController()
		{
			db = new ApplicationDbContext();
			AttorneyRepository = new AttorneyRepository();
		}

        public ActionResult Index(int? page)
        {
			userID = User.Identity.GetUserId();
			bool isAdmin = User.IsInRole("Admin");

			int pageSize = 20;
			var userAttornies = db.Attorneys.Where(a => a.UserId == userID || isAdmin);
			int count = userAttornies.Count();
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

			var attornies = userAttornies
						.OrderBy(c => c.Id)
						.Skip(startIndex)
						.Take(pageSize)
						.ToList();

			ViewBag.NumOfPages = numOfPages;
			ViewBag.CurrentPage = page;

			return View(attornies);
		}

        public ActionResult Details(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null || attorney.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
        {
			userID = User.Identity.GetUserId();

			if (ModelState.IsValid)
            {
				
				AttorneyRepository.InsertAttorney(userID, 
													attorney.FirstName, 
													attorney.LastName, 
													attorney.AFM,
													attorney.City);
                return RedirectToAction("Index");
            }

            return View(attorney);
        }

        public ActionResult Edit(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null || attorney.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
        {
			userID = User.Identity.GetUserId();
			
			Attorney attorneyToEdit = db.Attorneys.Find(attorney.Id);

			if (ModelState.IsValid && attorneyToEdit.UserId == userID)
            {
				attorneyToEdit.FirstName = attorney.FirstName;
				attorneyToEdit.LastName = attorney.LastName;
				attorneyToEdit.AFM = attorney.AFM;
				attorneyToEdit.City = attorney.City;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attorney);
        }

        public ActionResult Delete(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attorney attorney = db.Attorneys.Find(id);
            if (attorney == null || attorney.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(attorney);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			userID = User.Identity.GetUserId();

			Attorney attorney = db.Attorneys.Find(id);
			if (attorney == null || attorney.UserId != userID)
			{
				return HttpNotFound();
			}
            db.Attorneys.Remove(attorney);
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
