using CaseTracker.Models;
using CaseTracker.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaseTracker.ViewModels
{
	public class CaseViewModel
	{
		private ApplicationDbContext db;

		public CaseViewModel()
		{
			db = new ApplicationDbContext();
		}

		public virtual string Aa { get; set; }

		public int Id { get; set; }

		[DisplayName("Τύπος αρχείου")]
		[Required]
		public int DocumentTypeId { get; set; }
		public ICollection<DocumentType> DocumentTypesList { get; set; }

		[DisplayName("Δικαστήριο")]
		[Required]
		public int CourtId { get; set; }
		public ICollection<Court> CourtsList { get; set; }

		[DisplayName("Δικηγόρος")]
		[Required]
		public int AttorneyId { get; set; }
		public ICollection<Attorney> AttorneysList { get; set; }

		[DisplayName("Ημερομηνία ανάθεσης")]
		[DataType(DataType.Date)]
		//[Required]
		public DateTime DateOfAssignment { get; set; }

		[DisplayName("Ημερομηνία υποβολής")]
		[DataType(DataType.Date)]
		//[Required]
		public DateTime DateOfSubmission { get; set; }

		[DisplayName("Ημερομηνία επιστροφής")]
		[DataType(DataType.Date)]
		//[Required]
		public DateTime DateOfEnd { get; set; }

		public string Notes { get; set; }

		[DisplayName("Κατήγορος")]
		[Required]
		public int? ProsecutionId { get; set; }
		public ICollection<Party> ProsecutionList { get; set; }

		[DisplayName("Υπεράσπιση")]
		[Required]
		public int? DefenseId { get; set; }
		public ICollection<Party> DefenseList { get; set; }

		[DisplayName("Παραλαβών")]
		[Required]
		public int? RecipientId { get; set; }
		public ICollection<Party> RecipientList { get; set; }

		[ForeignKey("DeedResult")]
		[DisplayName("Αποτέλεσμα επίδοσης")]
		public int? DeedResultId { get; set; }
		public ICollection<DeedResult> DeedResultList { get; set; }

		[DisplayName("Ημερομηνία επίδοσης")]
		[DataType(DataType.Date)]
		//[Required]
		public DateTime DateOfDeed { get; set; }

		[ForeignKey("Zone")]
		[DisplayName("Ζώνη")]
		public int? ZoneId { get; set; }
		public ICollection<Zone> ZoneList { get; set; }

		public void PrepareLists()
		{
			AttorneysList = db.Attorneys.ToList();
			CourtsList = db.Courts.ToList();
			DocumentTypesList = db.DocumentTypes.ToList();
			ProsecutionList = db.Parties.Where(c => c.CaseRole.Type == RoleType.Accuse).ToList();
			DefenseList = db.Parties.Where(c => c.CaseRole.Type == RoleType.Defend).ToList();
			RecipientList = db.Parties.Where(c => c.CaseRole.Type == RoleType.Receive).ToList();
			DeedResultList = db.DeedResults.ToList();
			ZoneList = db.Zones.ToList();
		}
	}
}