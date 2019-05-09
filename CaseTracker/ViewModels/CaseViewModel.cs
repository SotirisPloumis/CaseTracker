using App_LocalResources;
using CaseTracker.Models;
using CaseTracker.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CaseTracker.ViewModels
{
	public class CaseViewModel
	{
		private ApplicationDbContext db;

		public CaseViewModel()
		{
			db = new ApplicationDbContext();
		}

		public virtual string Aa { get; set; }

		public int Id { get; set; }

		[Display(Name = "State", ResourceType = typeof(GlobalRes))]
		public bool IsFinished { get; set; }

		[Display(Name = "Document_Type", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int DocumentTypeId { get; set; }
		public ICollection<DocumentType> DocumentTypesList { get; set; }

		[Display(Name = "Court", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? CourtId { get; set; }
		public ICollection<Court> CourtsList { get; set; }

		[Display(Name = "Attorney", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? AttorneyId { get; set; }
		public ICollection<Attorney> AttorneysList { get; set; }

		[Display(Name = "Date_Assignment", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public DateTime DateOfAssignment { get; set; }

		[Display(Name = "Date_Submission", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public DateTime DateOfSubmission { get; set; }

		[Display(Name = "Date_return", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public DateTime DateOfEnd { get; set; }

		[Display(Name = "Notes", ResourceType = typeof(GlobalRes))]
		public string Notes { get; set; }

		[Display(Name = "Prosecution", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? ProsecutionId { get; set; }
		public ICollection<Party> ProsecutionList { get; set; }

		[Display(Name = "Defense", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? DefenseId { get; set; }
		public ICollection<Party> DefenseList { get; set; }

		[Display(Name = "Recipient", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? RecipientId { get; set; }
		public ICollection<Party> RecipientList { get; set; }

		[Display(Name = "Result_Service", ResourceType = typeof(GlobalRes))]
		public int DeedResultId { get; set; }
		public ICollection<DeedResult> DeedResultList { get; set; }

		[Display(Name = "Date_Service", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public DateTime DateOfDeed { get; set; }

		[Display(Name = "Zone", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int ZoneId { get; set; }
		public ICollection<Zone> ZoneList { get; set; }

		public void PrepareLists(string userID)
		{
			AttorneysList = db.Attorneys.Where(c => c.UserId == userID).ToList();
			CourtsList = db.Courts.Where(c => c.UserId == userID).ToList();

			DocumentTypesList = db.DocumentTypes.ToList();
			foreach(var i in DocumentTypesList)
			{
				i.Description = GlobalRes.ResourceManager.GetString(i.Description);
			}

			ProsecutionList = db.Parties
							.Where(c => c.UserId == userID)
							.ToList();

			DefenseList = db.Parties
							.Where(c => c.UserId == userID)
							.ToList();

			RecipientList = db.Parties
							.Where(c => c.UserId == userID)
							.ToList();

			DeedResultList = db.DeedResults.ToList();
			foreach(var i in DeedResultList)
			{
				i.Result = GlobalRes.ResourceManager.GetString(i.Result);
			}

			ZoneList = db.Zones.ToList();
			foreach(var i in ZoneList)
			{
				i.Name = GlobalRes.ResourceManager.GetString(i.Name);
			}
		}
	}
}