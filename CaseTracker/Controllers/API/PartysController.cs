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
	public class PartysController : ApiController
	{
		private PartyRepository PartyRepository;

		public PartysController()
		{
			PartyRepository = new PartyRepository();
		}

		//public IHttpActionResult Create([Bind(Include = "Id,FirstName,LastName,AFM,City")] Attorney attorney)
		[HttpPost]
		public IHttpActionResult Create(string FirstName, 
										string LastName, 
										string FathersName, 
										int? CaseRoleId, 
										string Street, 
										string City, 
										string Municipality, 
										string PostCode, 
										string WorkPhone, 
										string HomePhone, 
										string MobilePhone, 
										string FAX, 
										string AFM, 
										string IDCard)
		{
			//string userID = User.Identity.GetUserId();
			string userID = "c7dc8f37-9b2f-450c-bb42-90343f36b70e";

			if (FirstName != null && LastName != null && AFM != null)
			{

				int insertedId = PartyRepository.InsertParty(userID,
															 FirstName,
															 LastName,
															 FathersName,
															 CaseRoleId,
															 Street,
															 City,
															 Municipality,
															 PostCode,
															 WorkPhone,
															 HomePhone,
															 MobilePhone,
															 FAX,
															 AFM,
															 IDCard);
				return Ok(insertedId);
			}

			return BadRequest("bad input");
		}
	}
}
