using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Case
	{
		public int Id { get; set; }

		public int Aa { get; set; }

		public string Type { get; set; }

        public DateTime DateOfSubmission { get; set; }

        public DateTime DateOfEnd { get; set; }

        public DateTime DateOfAssigmnent { get; set; }

        public string Attorney { get; set; }

        public string Court { get; set; }


    }
}