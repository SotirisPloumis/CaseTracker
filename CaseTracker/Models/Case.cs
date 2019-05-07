using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using CaseTracker.ViewModels;
using App_LocalResources;

namespace CaseTracker.Models
{
	public class Case
	{
		public Case()
		{

		}

		public Case(string userID)
		{
			this.UserId = userID;
		}

		public int Id { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[StringLength(450)]
		[Display(Name = "aa", ResourceType = typeof(GlobalRes))]
		public string Aa { get; set; }

		[Display(Name = "State", ResourceType = typeof(GlobalRes))]
		public bool IsFinished { get; set; }

		[ForeignKey("DocumentType")]
		[Display(Name = "Document_Type", ResourceType = typeof(GlobalRes))]
		public int DocumentTypeId { get; set; }

		public virtual DocumentType DocumentType { get; set; }

		[ForeignKey("Court")]
		[Display(Name = "Court", ResourceType = typeof(GlobalRes))]
		public int? CourtId { get; set; }

		public virtual Court Court { get; set; }

		[ForeignKey("Attorney")]
		[Display(Name = "Attorney", ResourceType = typeof(GlobalRes))]
		public int? AttorneyId { get; set; }

		public virtual Attorney Attorney { get; set; }

		[Display(Name = "Date_Assignment", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		public DateTime DateOfAssignment { get; set; }

		[Display(Name = "Date_Submission", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		public DateTime DateOfSubmission { get; set; }

		[Display(Name = "Date_return", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		public DateTime DateOfEnd { get; set; }

		[Display(Name = "Notes", ResourceType = typeof(GlobalRes))]
		public string Notes { get; set; }

		[ForeignKey("Prosecution")]
		[Display(Name = "Prosecution", ResourceType = typeof(GlobalRes))]
		public int? ProsecutionId { get; set; }

		public virtual Party Prosecution { get; set; }

		[ForeignKey("Defense")]
		[Display(Name = "Defense", ResourceType = typeof(GlobalRes))]
		public int? DefenseId { get; set; }

		public virtual Party Defense { get; set; }

		[ForeignKey("Recipient")]
		[Display(Name = "Recipient", ResourceType = typeof(GlobalRes))]
		public int? RecipientId { get; set; }

		public virtual Party Recipient { get; set; }

		[ForeignKey("DeedResult")]
		[Display(Name = "Result_Service", ResourceType = typeof(GlobalRes))]
		public int DeedResultId { get; set; }

		public virtual DeedResult DeedResult { get; set; }

		[Display(Name = "Date_Service", ResourceType = typeof(GlobalRes))]
		[DataType(DataType.Date)]
		public DateTime DateOfDeed { get; set; }

		[ForeignKey("Zone")]
		[Display(Name = "Zone", ResourceType = typeof(GlobalRes))]
		public int ZoneId { get; set; }

		public virtual Zone Zone { get; set; }

		public void Update(CaseViewModel vm)
		{
			Aa = vm.Aa;
			DocumentTypeId = vm.DocumentTypeId;
			CourtId = vm.CourtId;
			AttorneyId = vm.AttorneyId;
			DateOfAssignment = vm.DateOfAssignment;
			DateOfSubmission = vm.DateOfAssignment;
			DateOfEnd = vm.DateOfEnd;
			Notes = vm.Notes;
			ProsecutionId = vm.ProsecutionId;
			DefenseId = vm.DefenseId;
			RecipientId = vm.RecipientId;
			DeedResultId = vm.DeedResultId;
			DateOfDeed = vm.DateOfDeed;
			ZoneId = vm.ZoneId;
			IsFinished = vm.IsFinished;
		}
	}
}