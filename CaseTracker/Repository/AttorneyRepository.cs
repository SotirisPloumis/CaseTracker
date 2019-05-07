using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;

namespace CaseTracker.Repository
{
	public class AttorneyRepository
	{
		ApplicationDbContext db;

		public AttorneyRepository()
		{
			db = new ApplicationDbContext();
		}

		public int InsertAttorney(Attorney attorney)
		{
			db.Attorneys.Add(attorney);
			db.SaveChanges();

			return attorney.Id;
		}

		public int InsertAttorney(string userID, 
								  string FirstName, 
								  string LastName, 
								  string AFM, 
								  string City)
		{
			Attorney attorney = new Attorney
			{
				UserId = userID,
				FirstName = FirstName,
				LastName = LastName,
				AFM = AFM,
				City = City
			};
			db.Attorneys.Add(attorney);
			db.SaveChanges();

			return attorney.Id;
		}
	}
}