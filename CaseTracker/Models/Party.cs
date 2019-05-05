using App_LocalResources;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseTracker.Repository;
using System.Linq;

namespace CaseTracker.Models
{

	public class Party
	{
		public Party()
		{
			db = new ApplicationDbContext();
		}

		public ApplicationDbContext db;

		public int Id { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		[Display(Name = "FirstName", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string FirstName { get; set; }

		[Display(Name = "LastName", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string LastName { get; set; }

		[Display(Name = "FatherName", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public string FathersName { get; set; }

		[Display(Name = "FullName", ResourceType = typeof(GlobalRes))]
		public string FullName
		{
			get
			{
				string sonOf = FathersName == null ? "" : $"{ GlobalRes.SonOf} { FathersName}";
				return $"{LastName} {FirstName} {sonOf}";
			}
		}

		[ForeignKey("CaseRole")]
		[Display(Name = "CaseRole", ResourceType = typeof(GlobalRes))]
		[Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "This_field_is_required")]
		public int? CaseRoleId { get; set; }

		public virtual CaseRole CaseRole { get; set; }

		[NotMapped]
		public List<CaseRole> TranslatedRoles;

		[Display(Name = "Street", ResourceType = typeof(GlobalRes))]
		public string Street { get; set; }

		[Display(Name = "City", ResourceType = typeof(GlobalRes))]
		public string City { get; set; }

		[Display(Name = "Municipality", ResourceType = typeof(GlobalRes))]
		public string Municipality { get; set; }

		[Display(Name = "PostalCode", ResourceType = typeof(GlobalRes))]
		public string PostCode { get; set; }

		[Display(Name = "FullAddress", ResourceType = typeof(GlobalRes))]
		public string FullAddress
		{
			get
			{
				return $"{Street}, {Municipality} {PostCode}, {City}";
			}
		}

		[Display(Name = "WorkPhone", ResourceType = typeof(GlobalRes))]
		public string WorkPhone { get; set; }

		[Display(Name = "HomePhone", ResourceType = typeof(GlobalRes))]
		public string HomePhone { get; set; }

		[Display(Name = "MobilePhone", ResourceType = typeof(GlobalRes))]
		public string MobilePhone { get; set; }

		[Display(Name = "FAX", ResourceType = typeof(GlobalRes))]
		public string FAX { get; set; }

		[Display(Name = "TaxID", ResourceType = typeof(GlobalRes))]
		public string AFM { get; set; }

		[Display(Name = "IDCard", ResourceType = typeof(GlobalRes))]
		public string IDCard { get; set; }

		public void TranslateRoles()
		{
			TranslatedRoles = db.CaseRoles.ToList();

			foreach (var i in TranslatedRoles)
			{
				i.Title = GlobalRes.ResourceManager.GetString(i.Title);
			}
		}
	}
}