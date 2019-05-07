using CaseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseTracker.Repository;

namespace CaseTracker.Controllers.API
{
    public class AttorniesController : ApiController
    {
		AttorneyRepository AttorneyRepository;

		public AttorniesController()
		{
			AttorneyRepository = new AttorneyRepository();
		}

        // GET: api/Attornies
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Attornies/5
        public IQueryable<Attorney> Get(int id)
        {
            return AttorneyRepository.getAttorney(id);
        }

        // POST: api/Attornies
        public IHttpActionResult Post([FromBody]Attorney a)
        {
			a.UserId = "b4738ca1-664a-4004-b9b8-de4c4098edde";

			int id = AttorneyRepository.InsertAttorney(a);

			return Ok(id);
        }

        // PUT: api/Attornies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Attornies/5
        public void Delete(int id)
        {
        }
    }
}
