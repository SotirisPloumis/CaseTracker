using CaseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CaseTracker.ViewModels;

namespace CaseTracker.Repository
{
	public class CaseRepository
	{
		private ApplicationDbContext db;

		public CaseRepository()
		{
			db = new ApplicationDbContext();
		}

		public ICollection<Case> GetCases(string userID, bool isAdmin)
		{
			return db.Cases
						.Include(c => c.Attorney)
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.Include(c => c.Zone)
						.Where(c => c.UserId == userID || isAdmin)
						.OrderByDescending(c => c.Id)
						.ToList();
		}

		public ICollection<Case> GetBookCases(string userID, bool isAdmin)
		{
			return db.Cases
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.Where(c => c.UserId == userID || isAdmin)
						.OrderByDescending(c => c.Id)
						.ToList();
		}

		public ICollection<Case> GetPinakioCases(string userID, bool isAdmin)
		{
			return db.Cases
						.Include(c => c.Court)
						.Include(c => c.DocumentType)
						.Include(c => c.Prosecution)
						.Include(c => c.Defense)
						.Include(c => c.Recipient)
						.Include(c => c.DeedResult)
						.Include(c => c.Zone)
						.Where(c => c.UserId == userID || isAdmin)
						.Where(c => c.DeedResult.IsPayable && !c.IsFinished)
						.OrderByDescending(c => c.Id)
						.ToList();
		}

		public int InsertCaseFromViewModel(string userID, CaseViewModel vm)
		{
			Case newCase = new Case(userID);
			newCase.Update(vm);

			db.Cases.Add(newCase);
			db.SaveChanges();

			return newCase.Id;
		}
	}
}