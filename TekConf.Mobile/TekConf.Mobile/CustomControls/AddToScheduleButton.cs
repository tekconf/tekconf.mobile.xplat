using Xamarin.Forms;

namespace TekConf.Mobile.Controls
{
	public class AddToScheduleButton : Button 
	{
		public AddToScheduleButton ()
		{
			this.BackgroundColor = Color.Blue;
			this.TextColor = Color.White;
			this.Font = Device.OnPlatform (
				iOS:Font.OfSize ("OpenSans-Light", 18),
				Android:Font.SystemFontOfSize (NamedSize.Medium),
				WinPhone:Font.SystemFontOfSize (NamedSize.Large)
			);
		}
	}
}