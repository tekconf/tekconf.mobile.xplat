using Xamarin.Forms;
using Ninject;

namespace TekConf.Mobile
{
	public class App : Application
	{
		public static StandardKernel Container { get; set; }

		//TODO : Add api key
		public static string InsightsKey = "<ADD YOUR KEY HERE>";

		[Insights]
		public App ()
		{
			var navigationPage = new NavigationPage(new MainPage ());
			navigationPage.BarBackgroundColor = Color.FromHex ("#72c02c"); 
			navigationPage.BarTextColor = Color.White;

			MainPage = navigationPage;
		}

		protected override void OnSleep ()
		{
			base.OnSleep ();
		}

		protected override void OnStart ()
		{
			base.OnStart ();
		}

		protected override void OnResume ()
		{
			base.OnResume ();
		}
	}

}