using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TekConf.Mobile.Models
{
	public class Speaker
	{
		[PrimaryKey, AutoIncrement, Column ("_id")]
		public int Id { get; set; }

		public string Slug { get; set; }

		public string ProfileImageUrl { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Description { get; set; }

		public string BlogUrl { get; set; }

		public string TwitterName { get; set; }

		public string FullName { get; set; }

//		[ManyToMany(typeof(SessionSpeaker))]
//		public List<Session> Sessions { get; set; } 

//		[ForeignKey(typeof(Session))]
//		public int SessionId { get; set; }
//
//		[ManyToOne]
//		public Session Session { get; set; }
	}	
}