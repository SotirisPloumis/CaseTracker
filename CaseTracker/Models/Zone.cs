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
	public class Zone
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[Display(Name = "ZoneCost", ResourceType = typeof(GlobalRes))]
		public decimal Cost { get; set; }

		[Display(Name = "Tax", ResourceType = typeof(GlobalRes))]
		public decimal Tax { get; set; }

		[NotMapped]
		[Display(Name = "Zone", ResourceType = typeof(GlobalRes))]
		public string TranslatedName
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Name);
			}
		}
	}
}