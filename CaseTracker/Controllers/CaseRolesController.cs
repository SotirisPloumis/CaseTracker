using CaseTracker.CustomAnnotations;
using CaseTracker.Models;
using CaseTracker.Repository;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CaseTracker.Controllers
{
	[NotAllowed(Roles = "Admin")]
	public class CaseRolesController : BaseController
	{
        private ApplicationDbContext db;

		public CaseRolesController()
		{
			db = new ApplicationDbContext();
		}
        
        public ActionResult Index(int? page)
        {
			int pageSize = 20;
			var CaseRoles = db.CaseRoles;
			int count = CaseRoles.Count();
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

			var caseRoleList = CaseRoles
									.OrderBy(t => t.Id)
									.Skip(startIndex)
									.Take(pageSize)
									.ToList();

			ViewBag.NumOfPages = numOfPages;
			ViewBag.CurrentPage = page;

			return View(caseRoleList);
		}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseRole caseRole = db.CaseRoles.Find(id);
            if (caseRole == null)
            {
                return HttpNotFound();
            }
            return View(caseRole);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Type")] CaseRole caseRole)
        {
            if (ModelState.IsValid)
            {
                db.CaseRoles.Add(caseRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseRole);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseRole caseRole = db.CaseRoles.Find(id);
            if (caseRole == null)
            {
                return HttpNotFound();
            }
            return View(caseRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Type")] CaseRole caseRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseRole);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseRole caseRole = db.CaseRoles.Find(id);
            if (caseRole == null)
            {
                return HttpNotFound();
            }
            return View(caseRole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseRole caseRole = db.CaseRoles.Find(id);
            db.CaseRoles.Remove(caseRole);
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
