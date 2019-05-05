using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App_LocalResources;

namespace CaseTracker.Models
{
	public class DeedResult
	{
		public int Id { get; set; }

		public string Result { get; set; }

		[Display(Name = "Payable", ResourceType = typeof(GlobalRes))]
		public bool IsPayable { get; set; }

		[Display(Name = "Result", ResourceType = typeof(GlobalRes))]
		public string TranslatedResult
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Result);
			}
		}
	}
}