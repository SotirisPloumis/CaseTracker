using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_LocalResources;

namespace CaseTracker.Models
{
	public class DeedResult
	{
		public int Id { get; set; }

		public string Result { get; set; }

		public string TranslatedResult
		{
			get
			{
				return GlobalRes.ResourceManager.GetString(Result);
			}
		}
	}
}