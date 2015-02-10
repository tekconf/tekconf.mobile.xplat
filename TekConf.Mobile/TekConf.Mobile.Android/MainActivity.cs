using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin;
using Xamarin.Forms;

namespace TekConf.Mobile.Droid
{
	[Activity (Label = "TekConf", MainLauncher = true, Icon="@drawable/Icon", 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var bootstrapper = new Bootstrapper ();
			bootstrapper.Automapper ();

			IoC.Initialize ();
			Insights.Initialize (App.InsightsKey, this);

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ()); // method is new in 1.3
		}
	}
}