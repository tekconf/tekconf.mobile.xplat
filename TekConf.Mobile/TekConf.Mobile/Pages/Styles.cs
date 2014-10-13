using System;
using Xamarin.Forms;

namespace TekConf.Mobile
{
	public class Styles
	{
//		public static readonly Font LabelFont =
//			Font.SystemFontOfSize(Device.OnPlatform(35, 40, 50), FontAttributes.Bold);

		public static readonly Font LabelFont = Device.OnPlatform (
			                                      Font.OfSize ("OpenSans-Light", 16),
			                                      Font.SystemFontOfSize (NamedSize.Medium),
			                                      Font.SystemFontOfSize (NamedSize.Large)
		                                      );
	}
}