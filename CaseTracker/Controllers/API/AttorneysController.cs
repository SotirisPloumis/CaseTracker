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
	public class AttorneysController : ApiController
	{
		private AttorneyRepository AttorneyRepository;

		public AttorneysController()
		{
			AttorneyRepository = new AttorneyRepository();
		}

		//public IHttpActionResult Create([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
		[HttpPost]
		public IHttpActionResult Create(string FirstName, string LastName, string AFM, string City)
		{
			string userID = User.Identity.GetUserId();
			//string userID = "c7dc8f37-9b2f-450c-bb42-90343f36b70e";

			if (FirstName != null && LastName != null && AFM != null)
			{

				int insertedId = AttorneyRepository.InsertAttorney(userID,
													FirstName,
													LastName,
													AFM,
													City);
				return Ok(insertedId);
			}

			return BadRequest("bad input");
		}
	}
}
