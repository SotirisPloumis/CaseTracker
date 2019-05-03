using App_LocalResources;
using CaseTracker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CaseTracker.ViewModels
{
	public class EditCaseViewModel : CaseViewModel
	{
		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAAEdit", "Cases", AdditionalFields = "Id", ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "DuplicateAA")]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		[Display(Name = "aa", ResourceType = typeof(GlobalRes))]
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