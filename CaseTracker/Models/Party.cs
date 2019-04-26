using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Party
	{
		public int Id { get; set; }

		[DisplayName("First name")]
		public string FirstName { get; set; }

		[DisplayName("Last name")]
		public string LastName { get; set; }

		[DisplayName("Fathers name")]
		public string FathersName { get; set; }

		[DisplayName("Full name")]
		public string FullName
		{
			get
			{
				return $"{LastName} {FirstName} του {FathersName}";
			}
		}

		[ForeignKey("CaseRole")]
		[DisplayName("Role")]
		public int? CaseRoleId { get; set; }

		public virtual CaseRole CaseRole { get; set; }

		public string Street { get; set; }

		public string City { get; set; }

		public string Municipality { get; set; }

		[DisplayName("Postal Code")]
		public string PostCode { get; set; }

		[DisplayName("Full address")]
		public string FullAddress
		{
			get
			{
				return $"{Street}, {Municipality} {PostCode}, {City}";
			}
		}

		[DisplayName("Work Phone")]
		public string WorkPhone { get; set; }

		[DisplayName("Home Phone")]
		public string HomePhone { get; set; }

		[DisplayName("Mobile Phone")]
		public string MobilePhone { get; set; }

		public string FAX { get; set; }

		[DisplayName("AFM")]
		public string AFM { get; set; }

		public string IDCard { get; set; }
	}
}