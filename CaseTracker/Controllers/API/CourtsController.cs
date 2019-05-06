using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseTracker.Repository;
using Microsoft.AspNet.Identity;
using CaseTracker.Models;

namespace CaseTracker.Controllers.API
{
	public class CourtsController : ApiController
	{
		private CourtRepository CourtsRepository;

		public CourtsController()
		{
			CourtsRepository = new CourtRepository();
		}

		[HttpPost]
		public IHttpActionResult Create(string Name)
		{
			string userID = User.Identity.GetUserId();
			//string userID = "c7dc8f37-9b2f-450c-bb42-90343f36b70e";

			if (Name != null)
			{

				int insertedId = CourtsRepository.InsertCourt(userID, Name);
				return Ok(insertedId);
			}

			return BadRequest("bad input");
		}
	}
}
