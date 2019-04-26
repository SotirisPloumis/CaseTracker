﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Attorney
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string AFM { get; set; }

		public string City { get; set; }

		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}

		[DisplayName("Attorney")]
		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}