using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Case
	{
		public int Id { get; set; }

		public string Aa { get; set; }

		public string Type { get; set; }

		[ForeignKey("Court")]
		public int CourtId { get; set; }

		public Court Court { get; set; }

		[ForeignKey("Attorney")]
		public int AttorneyId { get; set; }

		public Attorney Attorney { get; set; }

		public DateTime DateOfAssignment { get; set; }

		public DateTime DateOfSubmission { get; set; }

		public DateTime DateOfEnd { get; set; }
	}
}