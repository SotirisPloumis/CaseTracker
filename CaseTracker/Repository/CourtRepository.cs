using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;
using CaseTracker.ViewModels;

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

			return InsertCourt(court);
		}

		public int InsertCourt(string userID, CreateCaseViewModel vm)
		{
			return InsertCourt(userID, vm.CourtName);
		}
	}
}