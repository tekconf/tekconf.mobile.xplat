using Xamarin.Forms;

namespace TekConf.Mobile.Controls
{
	public class ConferenceDetailTitleLabel : Label 
	{
		public ConferenceDetailTitleLabel ()
		{
			this.Font = Device.OnPlatform (
				iOS:Font.OfSize ("OpenSans-Bold", 32),
				Android:Font.SystemFontOfSize (NamedSize.Medium),
				WinPhone:Font.SystemFontOfSize (NamedSize.Large)
			);
		}
	}
}