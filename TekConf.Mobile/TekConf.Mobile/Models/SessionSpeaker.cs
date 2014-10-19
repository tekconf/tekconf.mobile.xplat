using SQLiteNetExtensions.Attributes;

namespace TekConf.Mobile.Models
{
	public class SessionSpeaker
	{
		[ForeignKey(typeof(Session))]
		public int SessionId { get; set; }

		[ForeignKey(typeof(Speaker))]
		public int SpeakerId { get; set; }
	}
}