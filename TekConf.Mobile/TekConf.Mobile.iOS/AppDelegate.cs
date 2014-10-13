using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin;

namespace TekConf.Mobile.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
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

			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.RootViewController = App.GetMainPage().CreateViewController();

			window.MakeKeyAndVisible();

			return true;
		}
	}
}