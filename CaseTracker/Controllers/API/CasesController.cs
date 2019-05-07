using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseTracker.Repository;

namespace CaseTracker.Controllers.API
{
    public class CasesController : ApiController
    {
		

        // GET: api/Cases
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cases/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cases
        public void Post([FromBody]string name, string title)
        {
        }

        // PUT: api/Cases/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cases/5
        public void Delete(int id)
        {
        }
    }
}
