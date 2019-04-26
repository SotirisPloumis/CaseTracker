using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CaseTracker.Models;

namespace CaseTracker.ViewModels
{
	public class CaseFormViewModel
	{
		public int Id { get; set; }

		public int Aa { get; set; }

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
	}
}