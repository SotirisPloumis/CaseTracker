using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace CaseTracker.Models
{
	public class Case
	{
		public int Id { get; set; }

		//public string CreatedBy { get; set; }

		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAA", "Cases", ErrorMessage = "Duplicate AA")]
		public string Aa { get; set; }

		[ForeignKey("DocumentType")]
		[DisplayName("Document type")]
		public int DocumentTypeId { get; set; }

		public virtual DocumentType DocumentType { get; set; }

		[ForeignKey("Court")]
		[DisplayName("Court")]
		public int CourtId { get; set; }

		public virtual Court Court { get; set; }

		[ForeignKey("Attorney")]
		[DisplayName("Attorney")]
		public int AttorneyId { get; set; }

		public virtual Attorney Attorney { get; set; }

		[DisplayName("Date of assignment")]
		[DataType(DataType.Date)]
		public DateTime DateOfAssignment { get; set; }

		[DisplayName("Date of submission")]
		[DataType(DataType.Date)]
		public DateTime DateOfSubmission { get; set; }

		[DisplayName("Date of return")]
		[DataType(DataType.Date)]
		public DateTime DateOfEnd { get; set; }

		public string Notes { get; set; }

		[ForeignKey("Prosecution")]
		[DisplayName("Prosecution")]
		public int? ProsecutionId { get; set; }

		public virtual Party Prosecution { get; set; }

		[ForeignKey("Defense")]
		[DisplayName("Defense")]
		public int? DefenseId { get; set; }

		public virtual Party Defense { get; set; }

		[ForeignKey("Recipient")]
		[DisplayName("Recipient")]
		public int? RecipientId { get; set; }

		public virtual Party Recipient { get; set; }

		[ForeignKey("DeedResult")]
		[DisplayName("Deed result")]
		public int? DeedResultId { get; set; }

		public virtual DeedResult DeedResult { get; set; }

		[DisplayName("Date of deed")]
		[DataType(DataType.Date)]
		public DateTime DateOfDeed { get; set; }

		[ForeignKey("Zone")]
		[DisplayName("Zone")]
		public int? ZoneId { get; set; }

		public virtual Zone Zone { get; set; }
		
	}
}