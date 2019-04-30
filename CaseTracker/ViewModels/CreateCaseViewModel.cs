using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseTracker.Models;
using CaseTracker.Repository;

namespace CaseTracker.ViewModels
{
	public class CreateCaseViewModel : CaseViewModel
	{
		[StringLength(450)]
		[Index(IsUnique = true)]
		[Remote("UniqueAACreate", "Cases", ErrorMessage = "Duplicate AA")]
		[Required]
		[DisplayName("ΑΑ")]
		public override string Aa { get; set; }
	}
}