using CaseTracker.Models;
using CaseTracker.Repository;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CaseTracker.Controllers
{
	[Authorize]
    public class CourtController : BaseController
	{
		private ApplicationDbContext db;
		private CourtRepository CourtRepository;
		private string userID;

		public CourtController()
		{
			db = new ApplicationDbContext();
			CourtRepository = new CourtRepository();
		}

        public ActionResult Index(int? page)
        {
			userID = User.Identity.GetUserId();
			bool isAdmin = User.IsInRole("Admin");

			int pageSize = 3;
			var userCourts = db.Courts.Where(a => a.UserId == userID || isAdmin);
			int count = userCourts.Count();
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

			var courts = userCourts
						.OrderBy(c => c.Id)
						.Skip(startIndex)
						.Take(pageSize)
						.ToList();

			ViewBag.NumOfPages = numOfPages;
			ViewBag.CurrentPage = page;

			return View(courts);
		}

        public ActionResult Details(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = db.Courts.Find(id);
            if (court == null || court.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Court court)
        {
			userID = User.Identity.GetUserId();

			if (ModelState.IsValid)
            {
				CourtRepository.InsertCourt(userID, court.Name);
                return RedirectToAction("Index");
            }

            return View(court);
        }

        public ActionResult Edit(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = db.Courts.Find(id);
            if (court == null || court.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Court court)
        {
			userID = User.Identity.GetUserId();

			Court courtToEdit = db.Courts.Find(court.Id);

			if (ModelState.IsValid && courtToEdit.UserId == userID)
            {
				courtToEdit.Name = court.Name;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(court);
        }

        public ActionResult Delete(int? id)
        {
			userID = User.Identity.GetUserId();

			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Court court = db.Courts.Find(id);
            if (court == null || court.UserId != userID)
            {
                return HttpNotFound();
            }
            return View(court);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			userID = User.Identity.GetUserId();

			Court court = db.Courts.Find(id);
			if (court == null || court.UserId != userID)
			{
				return HttpNotFound();
			}
            db.Courts.Remove(court);
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
