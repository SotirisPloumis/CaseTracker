using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseTracker.Models;
using CaseTracker.Repository;

namespace CaseTracker.Controllers.API
{
    public class PartiesController : ApiController
    {
		PartyRepository PartyRepository;

		public PartiesController()
		{
			PartyRepository = new PartyRepository();
		}

        // GET: api/Parties
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Parties/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parties
        public IHttpActionResult Post([FromBody]Party party)
        {
			party.UserId = "b05c5fcc-f7cf-4111-a77b-cdea8c56cf7b";

			int id = PartyRepository.InsertParty(party);

			return Ok(id);
		}

        // PUT: api/Parties/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Parties/5
        public void Delete(int id)
        {
        }
    }
}
