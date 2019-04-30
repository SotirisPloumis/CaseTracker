using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Zone
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[DisplayName("Κόστος")]
		public Decimal Cost { get; set; }

		[DisplayName("ΦΠΑ")]
		public Decimal Tax { get; set; }
	}
}