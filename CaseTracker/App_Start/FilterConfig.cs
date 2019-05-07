using CaseTracker.Attributes;
using System.Web;
using System.Web.Mvc;

namespace CaseTracker
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new LocalizationAttribute("el"), 0);
		}
	}
}
