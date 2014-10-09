using System;
using System.Collections.Generic;

namespace TekConf.Mobile.Dtos
{
	public class Conference
	{
		public string Slug { get; set; }
		public string Name { get; set; }
		public DateTime? Start { get; set; }
		public DateTime? End { get; set; }
		public DateTime? CallForSpeakersOpens { get; set; }
		public DateTime? CallForSpeakersCloses { get; set; }
		public DateTime? RegistrationOpens { get; set; }
		public DateTime? RegistrationCloses { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public DateTime? LastUpdated { get; set; }
		public Address Address { get; set; }
		public string Tagline { get; set; }
		public string ImageUrl { get; set; }
		public string ImageUrlSquare { get; set; }
		public bool? IsLive { get; set; }
		public string HomepageUrl { get; set; }
		public string TwitterHashTag { get; set; }
		public string TwitterName { get; set; }
		public List<double> Position { get; set; }
		public int? DefaultTalkLength { get; set; }
		public List<object> Rooms { get; set; }
		public List<object> SessionTypes { get; set; }
		public List<object> Subjects { get; set; }
		public List<object> Rags { get; set; }
		public List<Session> Sessions { get; set; }
		public int? NumberOfSessions { get; set; }
		public bool? IsOnline { get; set; }
		public string DateRange { get; set; }
		public string FormattedAddress { get; set; }
	}}

