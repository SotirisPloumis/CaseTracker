using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using App_LocalResources;

namespace CaseTracker.Models
{
	public class DocumentType
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string TranslatedDescription
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Description);
			}
		}
	}
}