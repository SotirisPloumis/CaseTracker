using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class DocumentType
	{
		public int Id { get; set; }

		[DisplayName("Document type")]
		public string Description { get; set; }
	}
}