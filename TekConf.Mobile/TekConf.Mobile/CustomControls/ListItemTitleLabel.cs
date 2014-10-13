using System;
using Xamarin.Forms;

namespace TekConf.Mobile.Controls
{
	public class ListItemTitleLabel : Label 
	{
		public ListItemTitleLabel ()
		{
			this.Font = Device.OnPlatform (
				Font.OfSize ("OpenSans-Light", 16),
				Font.SystemFontOfSize (NamedSize.Medium),
				Font.SystemFontOfSize (NamedSize.Large)
			);
		}
	}

}