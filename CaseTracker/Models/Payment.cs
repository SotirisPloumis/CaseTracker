using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Payment
	{
		public int Id { get; set; }
		public string cardNumber { get; set; }
		public int expiresmonth { get; set; }
		public int expiresyear { get; set; }
		public string fname { get; set; }
		public string lname { get; set; }
	}
}