using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App_LocalResources;

namespace CaseTracker.Models
{
	public class DocumentType
	{
		public int Id { get; set; }

		public string Description { get; set; }

		[Display(Name = "Title", ResourceType = typeof(GlobalRes))]
		public string TranslatedDescription
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Description);
			}
		}
	}
}