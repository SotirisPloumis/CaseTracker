using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseTracker.Models;
using CaseTracker.Repository;

namespace CaseTracker.ViewModels
{
	public class EditCaseViewModel : CaseViewModel
	{

		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAAEdit", "Cases", AdditionalFields = "Id", ErrorMessage = "Duplicate AA")]
		[Required]
		[DisplayName("ΑΑ")]
		public override string Aa { get; set; }

		public void Update(Case caseToChange)
		{
			Aa = caseToChange.Aa;
			DocumentTypeId = caseToChange.DocumentTypeId;
			CourtId = caseToChange.CourtId;
			AttorneyId = caseToChange.AttorneyId;
			DateOfAssignment = caseToChange.DateOfAssignment;
			DateOfSubmission = caseToChange.DateOfAssignment;
			DateOfEnd = caseToChange.DateOfEnd;
			Notes = caseToChange.Notes;
			ProsecutionId = caseToChange.ProsecutionId;
			DefenseId = caseToChange.DefenseId;
			RecipientId = caseToChange.RecipientId;
			DeedResultId = caseToChange.DeedResultId;
			DateOfDeed = caseToChange.DateOfDeed;
			ZoneId = caseToChange.ZoneId;
		}
	}
}