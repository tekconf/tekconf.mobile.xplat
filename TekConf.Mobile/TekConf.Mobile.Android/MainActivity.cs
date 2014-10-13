using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace TekConf.Mobile.Droid
{
	[Activity (Label = "TekConf", MainLauncher = true, Icon="@drawable/Icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var bootstrapper = new Bootstrapper ();
			bootstrapper.Automapper ();

			IoC.Initialize ();
			Xamarin.Insights.Initialize (App.InsightsKey, this);

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (App.GetMainPage ());
		}
	}
}