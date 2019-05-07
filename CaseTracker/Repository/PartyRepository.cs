using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;
using CaseTracker.ViewModels;

namespace CaseTracker.Repository
{
	public class PartyRepository
	{
		ApplicationDbContext db;

		public PartyRepository()
		{
			db = new ApplicationDbContext();
		}

		public int InsertParty(Party party)
		{
			db.Parties.Add(party);
			db.SaveChanges();
			return party.Id;
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

			return InsertParty(party);
		}

		public int InsertParty(string userID,
								string FirstName,
								string LastName,
								string FathersName,
								int? CaseRoleId)
		{
			Party party = new Party()
			{
				UserId = userID,
				FirstName = FirstName,
				LastName = LastName,
				FathersName = FathersName,
				CaseRoleId = CaseRoleId
			};

			return InsertParty(party);
		}

		public int InsertPartyProsecution(string userID, CreateCaseViewModel vm)
		{
			return InsertParty(userID,
							   vm.ProsecutionFirstName,
							   vm.ProsecutionLastName,
							   vm.ProsecutionFathersName,
							   1);
		}

		public int InsertPartyDefense(string userID, CreateCaseViewModel vm)
		{
			return InsertParty(userID,
							   vm.DefenseFirstName,
							   vm.DefenseLastName,
							   vm.DefenseFathersName,
							   2);
		}

		public int InsertPartyRecipient(string userID, CreateCaseViewModel vm)
		{
			return InsertParty(userID,
							   vm.RecipientFirstName,
							   vm.RecipientLastName,
							   vm.RecipientFathersName,
							   3);
		}
	}
}