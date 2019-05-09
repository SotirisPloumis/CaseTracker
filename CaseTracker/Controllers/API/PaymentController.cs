using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CaseTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CaseTracker.Repository;

namespace CaseTracker.Controllers.API
{
	[Authorize]
    public class PaymentController : ApiController
    {
		private ApplicationDbContext db;
		private UserManager<ApplicationUser> UserManager;

		public PaymentController()
		{
			db = new ApplicationDbContext();
			UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
		}

        // GET: api/Payment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Payment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payment
        public IHttpActionResult Post([FromBody] Payment payment)
        {
			string userID = User.Identity.GetUserId();
			var user = UserManager.FindById(userID);
			user.IsPro = true;

			db.SaveChanges();

			return Ok(userID);
        }

        // PUT: api/Payment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Payment/5
        public void Delete(int id)
        {
        }
    }
}
