using System;
using Xamarin.Forms;

namespace TekConf.Mobile.Controls
{

	public class ListItemDefaultLabel : Label 
	{
		public ListItemDefaultLabel ()
		{
			this.Font = Device.OnPlatform (
				Font.OfSize ("OpenSans-Light", 14),
				Font.SystemFontOfSize (NamedSize.Medium),
				Font.SystemFontOfSize (NamedSize.Large)
			);
		}
	}
}