using CaseTracker.Models;
using CaseTracker.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseTracker.Controllers
{
	public class HomeController : BaseController
	{
		private ApplicationDbContext db;
		private UserManager<ApplicationUser> UserManager;

		public HomeController()
		{
			db = new ApplicationDbContext();
			UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
		}

		public ActionResult Index()
		{
			return View();
		}

		[Authorize]
		public ActionResult BecomePro()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user.IsPro)
			{
				return RedirectToAction("Pro", "Home");
			}
			return View();
		}

		[Authorize]
		public ActionResult Pro()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user.IsPro)
			{
				return View();
			}
			return RedirectToAction("BecomePro", "Home");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[Authorize]
		public ActionResult Unauthorized()
		{
			return View();
		}
	}
}