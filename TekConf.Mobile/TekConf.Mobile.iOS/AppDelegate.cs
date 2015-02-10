using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin;

namespace TekConf.Mobile.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			#if DEBUG
			Xamarin.Calabash.Start();
			#endif

			Insights.Initialize(App.InsightsKey);

			var bootstrapper = new Bootstrapper ();
			bootstrapper.Automapper ();

			IoC.Initialize ();

			Forms.Init ();
			FormsMaps.Init();

			LoadApplication (new App ());  // method is new in 1.3

			return base.FinishedLaunching (app, options);
		}
	}
}