using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;

namespace CaseTracker.Repository
{
	public class PartyRepository
	{
		ApplicationDbContext db;

		public PartyRepository()
		{
			db = new ApplicationDbContext();
		}

		public int InsertParty(string userID, 
								string FirstName, 
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
			Party party = new Party()
			{
				UserId = userID,
				FirstName = FirstName,
				LastName = LastName,
				FathersName = FathersName,
				CaseRoleId = CaseRoleId,
				Street = Street,
				City = City,
				Municipality = Municipality,
				PostCode = PostCode,
				WorkPhone = WorkPhone,
				HomePhone = HomePhone,
				MobilePhone = MobilePhone,
				FAX = FAX,
				AFM = AFM,
				IDCard = IDCard
			};
			
			db.Parties.Add(party);
			db.SaveChanges();
			return party.Id;
		}
	}
}