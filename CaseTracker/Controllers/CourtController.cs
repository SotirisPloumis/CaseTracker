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

		public CourtController()
		{
			db = new ApplicationDbContext();
			CourtRepository = new CourtRepository();
		}

        public ActionResult Index()
        {
			string userID = User.Identity.GetUserId();
			bool isAdmin = User.IsInRole("Admin");

			var courts = db.Courts
							.Where(c => c.UserId == userID || isAdmin)
							.ToList();

			return View(courts);
        }

        public ActionResult Details(int? id)
        {
			string userID = User.Identity.GetUserId();

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
			string userID = User.Identity.GetUserId();

			if (ModelState.IsValid)
            {
				CourtRepository.InsertCourt(userID, court.Name);
                return RedirectToAction("Index");
            }

            return View(court);
        }

        public ActionResult Edit(int? id)
        {
			string userID = User.Identity.GetUserId();

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
			string userID = User.Identity.GetUserId();

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
			string userID = User.Identity.GetUserId();

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
			string userID = User.Identity.GetUserId();

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
