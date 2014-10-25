using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TekConf.Mobile.Models
{
	public class Session
	{
		[PrimaryKey, AutoIncrement, Column ("_id")]
		public int Id { get; set; }

		public string Slug { get; set; }

		public string Title { get; set; }

		public string Room { get; set; }

		public string Difficulty { get; set; }

		public string Description { get; set; }

		public string TwitterHashTag { get; set; }

		public string SessionType { get; set; }

		public string SpeakerNames { get; set; }

		public string StartDescription { get; set; }

		//public DateTime? Start { get; set; }

		//public DateTime? End { get; set; }

//		public List<string> Links { get; set; }
//
//		public List<string> Tags { get; set; }
//
//		public List<string> Subjects { get; set; }
//
//		public List<string> Resources { get; set; }
//
//		public List<string> Prerequisites { get; set; }

//		[ForeignKey(typeof(Conference))]
//		public int ConferenceId { get; set; }

//		[ManyToOne]
//		public Conference Conference { get; set; }

		//[OneToMany(CascadeOperations = CascadeOperation.All)]
		[Ignore]
		public List<Speaker> Speakers { get; set; }

//		[ManyToMany(typeof(SessionSpeaker))]
//		public List<Speaker> Speakers { get; set; } 
	}
}