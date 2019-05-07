using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseTracker.Repository;
using CaseTracker.Models;

namespace CaseTracker.Controllers.API
{
    public class CourtsController : ApiController
    {
		CourtRepository CourtRepository;

		public CourtsController()
		{
			CourtRepository = new CourtRepository();
		}

        // GET: api/Courts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Courts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Courts
        public IHttpActionResult Post([FromBody] Court c)
        {
			c.UserId = "b05c5fcc-f7cf-4111-a77b-cdea8c56cf7b";

			int result = CourtRepository.InsertCourt(c);

			return Ok(result);
        }

        // PUT: api/Courts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Courts/5
        public void Delete(int id)
        {
        }
    }
}
