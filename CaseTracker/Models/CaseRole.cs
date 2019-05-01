using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public enum RoleType
	{
		Accuse = 1,
		Defend,
		Receive
	}

	public class CaseRole
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public RoleType Type { get; set; }
	}
}