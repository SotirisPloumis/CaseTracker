using App_LocalResources;
using System.ComponentModel.DataAnnotations;

namespace CaseTracker.Models
{
	public class Court
	{
		public int Id { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[Display(Name = "Court", ResourceType = typeof(GlobalRes))]
		public string Name { get; set; }
	}
}