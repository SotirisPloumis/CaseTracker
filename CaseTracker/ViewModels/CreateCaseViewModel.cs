using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseTracker.Models;

namespace CaseTracker.ViewModels
{
	public class CreateCaseViewModel
	{
		public int Id { get; set; }

		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAACreate", "Cases", ErrorMessage = "Duplicate AA")]
		[Required]
		public string Aa { get; set; }

		[DisplayName("Document type")]
		[Required]
		public int DocumentTypeId { get; set; }
		public ICollection<DocumentType> DocumentTypesList { get; set; }

		[DisplayName("Court")]
		[Required]
		public int CourtId { get; set; }
		public ICollection<Court> CourtsList { get; set; }

		[DisplayName("Attorney")]
		[Required]
		public int AttorneyId { get; set; }
		public ICollection<Attorney> AttorneysList { get; set; }

		[DisplayName("Date of assignment")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime DateOfAssignment { get; set; }

		[DisplayName("Date of submission")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime DateOfSubmission { get; set; }

		[DisplayName("Date of return")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime DateOfEnd { get; set; }

		public string Notes { get; set; }

		[DisplayName("Prosecution")]
		[Required]
		public int? ProsecutionId { get; set; }
		public ICollection<Party> ProsecutionList { get; set; }

		[DisplayName("Defense")]
		[Required]
		public int? DefenseId { get; set; }
		public ICollection<Party> DefenseList { get; set; }

		[DisplayName("Recipient")]
		[Required]
		public int? RecipientId { get; set; }
		public ICollection<Party> RecipientList { get; set; }
	}
}