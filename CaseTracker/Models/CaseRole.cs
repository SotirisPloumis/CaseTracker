using App_LocalResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseTracker.Models
{
	public enum RoleType
	{
		Accuse = 1,
		Defend,
		Receive
	}

	public class CaseRole
	{
		public int Id { get; set; }

		public string Title { get; set; }

		[NotMapped]
		public string TranslatedTitle
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Title);
			}
		}

		public RoleType Type { get; set; }
	}
}