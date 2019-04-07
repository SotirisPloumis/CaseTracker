using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class CaseParties
	{
		[ForeignKey("Case")]
		[Key]
		[Column(Order = 1)]
		public int CaseId { get; set; }

		public Case Case { get; set; }

		[ForeignKey("Party")]
		[Key]
		[Column(Order = 2)]
		public int PartyId { get; set; }

		public Party Party { get; set; }

		[ForeignKey("CaseRole")]
		public int RoleId { get; set; }

		public CaseRole CaseRole { get; set; }
	}
}