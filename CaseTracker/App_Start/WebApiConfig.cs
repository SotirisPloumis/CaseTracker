using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CaseTracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AttorneyAPI",
                routeTemplate: "api/attorneys/{FirstName}/{LastName}/{AFM}/{City}",
                defaults: new {Controller = "attorneys", City = RouteParameter.Optional }
            );
			config.Routes.MapHttpRoute(
				name: "Court",
				routeTemplate: "api/courts/{Name}",
				defaults: new { Controller = "courts", City = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "Party",
				routeTemplate: "api/partys/{FirstName}/{LastName}/{CaseRoleId}/" 
							   //+"{FathersName}" +
							   //"/{Street}/" +
							   //"{City}/{Municipality}/{PostCode}/{WorkPhone}/{HomePhone}/{MobilePhone}" +
							   //"/{FAX}/{AFM}/{IDCard}"
							   ,
				defaults: new { Controller = "partys", FathersName = RouteParameter.Optional,
					//Street = RouteParameter.Optional,
					//City = RouteParameter.Optional,
					//Municipality = RouteParameter.Optional,
					//PostCode = RouteParameter.Optional,
					//WorkPhone = RouteParameter.Optional,
					//HomePhone = RouteParameter.Optional,
					//MobilePhone = RouteParameter.Optional,
					//FAX = RouteParameter.Optional,
					//AFM = RouteParameter.Optional,
					//IDCard = RouteParameter.Optional,
				}
			);
		}
    }
}
