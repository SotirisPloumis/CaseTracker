using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaseTracker.Helper
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, 
												string name, 
												RouteData routeData, 
												string lang)
        {
			foreach (var i in routeData.Values)
			{
				//Debug.Print(i.Key + " " + i.Value);
				//Debug.Print("lang:" + lang);
			}

			var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
					routeValueDictionary["lang"] = lang;
                }
			}
			
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
		} 
		//@Url.LangSwitcher("English", ViewContext.RouteData, "en")
	}
}