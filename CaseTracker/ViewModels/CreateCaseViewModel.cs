using App_LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CaseTracker.ViewModels
{
	public class CreateCaseViewModel : CaseViewModel
	{
		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAACreate", "Cases", ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "DuplicateAA")]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		[Display(Name = "aa", ResourceType = typeof(GlobalRes))]
		public override string Aa { get; set; }

		//attorney

		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string AttorneyFirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string AttorneyLastName { get; set; }

		[Display(Name = "TaxID", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string AttorneyAFM { get; set; }

		[Display(Name = "City", ResourceType = typeof(GlobalRes))]
		public string AttorneyCity { get; set; }

		[HiddenInput(DisplayValue = true)]
		public bool newAttorney { get; set; }

		//court
		[Display(Name = "Court", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string CourtName { get; set; }

		[HiddenInput(DisplayValue = true)]
		public bool newCourt { get; set; }

		//party - prosecution
		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string ProsecutionFirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string ProsecutionLastName { get; set; }

		[Display(Name = "FatherName", ResourceType = typeof(GlobalRes))]
		public string ProsecutionFathersName { get; set; }

		[HiddenInput(DisplayValue = true)]
		public bool newProsecution { get; set; }

		//party - defense
		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string DefenseFirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string DefenseLastName { get; set; }

		[Display(Name = "FatherName", ResourceType = typeof(GlobalRes))]
		public string DefenseFathersName { get; set; }

		[HiddenInput(DisplayValue = true)]
		public bool newDefense { get; set; }

		//party - recipient
		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string RecipientFirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		//[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string RecipientLastName { get; set; }

		[Display(Name = "FatherName", ResourceType = typeof(GlobalRes))]
		public string RecipientFathersName { get; set; }

		[HiddenInput(DisplayValue = true)]
		public bool newRecipient { get; set; }
	}
}