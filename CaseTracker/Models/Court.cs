﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
	public class Court
	{
		public int Id { get; set; }

		[DisplayName("Court")]
		public string Name { get; set; }
	}
}