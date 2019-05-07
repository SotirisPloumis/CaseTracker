using App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Attorney
	{
		public int Id { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string FirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string LastName { get; set; }

		[Display(Name = "TaxID", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string AFM { get; set; }

		[Display(Name = "City", ResourceType = typeof(GlobalRes))]
		public string City { get; set; }

		[Display(Name = "Attorney", ResourceType = typeof(GlobalRes))]
		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}