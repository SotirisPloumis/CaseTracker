using App_LocalResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseTracker.Models
{
	public class Court
	{
		public int Id { get; set; }

		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[Display(Name = "Court", ResourceType = typeof(GlobalRes))]
		public string Name { get; set; }
	}
}