using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;

namespace CaseTracker.Repository
{
	public class CourtRepository
	{
		ApplicationDbContext db;

		public CourtRepository()
		{
			db = new ApplicationDbContext();
		}

		public int InsertCourt(Court court)
		{
			db.Courts.Add(court);
			db.SaveChanges();
			return court.Id;
		}

		public int InsertCourt(string userID, string Name)
		{
			Court court = new Court
			{
				UserId = userID,
				Name = Name
			};

			db.Courts.Add(court);
			db.SaveChanges();

			return court.Id;
		}
	}
}