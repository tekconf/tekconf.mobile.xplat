using System;
using System.Collections.Generic;

namespace TekConf.Mobile.Dtos
{
	public class Address
	{
		public int? StreetNumber { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalArea { get; set; }
		public string Country { get; set; }
	}

	}
