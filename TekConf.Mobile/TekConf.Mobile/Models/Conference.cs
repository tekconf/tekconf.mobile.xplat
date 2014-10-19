using System;
using System.Collections.Generic;
using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TekConf.Mobile.Models
{
	public class Conference
	{
		[PrimaryKey, AutoIncrement, Column ("_id")]
		public int Id { get; set; }

		[Unique]
		public string Slug { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public string Tagline { get; set; }

		public string ImageUrl { get; set; }

		public string ImageUrlSquare { get; set; }

		public string HomepageUrl { get; set; }

		public string TwitterHashTag { get; set; }

		public string TwitterName { get; set; }

		public string DateRange { get; set; }

		public string FormattedAddress { get; set; }

		public int? DefaultTalkLength { get; set; }

		public int? NumberOfSessions { get; set; }

		public bool? IsLive { get; set; }

		public bool? IsOnline { get; set; }

		public double? Latitude { get; set; }

		public double? Longitude { get; set; }

//		public DateTime? Start { get; set; }
//
//		public DateTime? End { get; set; }
//
//		public DateTime? CallForSpeakersOpens { get; set; }
//
//		public DateTime? CallForSpeakersCloses { get; set; }
//
//		public DateTime? RegistrationOpens { get; set; }
//
//		public DateTime? RegistrationCloses { get; set; }
//
//		public DateTime? LastUpdated { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.All)]
		public List<Session> Sessions { get; set; }

//		public List<string> Rooms { get; set; }
//
//		public List<string> SessionTypes { get; set; }
//
//		public List<string> Subjects { get; set; }
//
//		public List<string> Tags { get; set; }


		//public Address Address { get; set; }
	}
}