using Xamarin.Forms;
using Ninject;

namespace TekConf.Mobile
{
	public static class App
	{
		public static StandardKernel Container { get; set; }

		//TODO : Add api key
		public static string InsightsKey = "<ADD YOUR KEY HERE>";

		[Insights]
		public static Page GetMainPage ()
		{
			return new NavigationPage(new MainPage ());
			//return new NavigationPage (new ConferencesPage ());
		}
	}
}