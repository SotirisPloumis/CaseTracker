﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Party
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string AFM { get; set; }

		public string IDCard { get; set; }
	}
}