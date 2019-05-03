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
		[Remote("UniqueAACreate", "Cases", AdditionalFields = "Id", ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "DuplicateAA")]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		[Display(Name = "aa", ResourceType = typeof(GlobalRes))]
		public override string Aa { get; set; }
	}
}