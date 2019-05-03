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
			Debug.Print("-----" + lang);
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
				Debug.Print("bike");
                if (routeData.Values["lang"] as string == lang)
                {
					Debug.Print("vrike");
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
					Debug.Print("den vrike");
					routeValueDictionary["lang"] = lang;
                }
			}
			else
			{
				Debug.Print("den bike");
			}
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
		} 
		//@Url.LangSwitcher("English", ViewContext.RouteData, "en")
	}
}