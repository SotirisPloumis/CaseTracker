using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Zone
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Decimal Cost { get; set; }

		public Decimal Tax { get; set; }
	}
}