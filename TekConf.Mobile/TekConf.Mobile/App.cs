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
			var navigationPage = new NavigationPage(new MainPage ());
			navigationPage.BarBackgroundColor = Color.FromHex ("#72c02c"); 
			navigationPage.BarTextColor = Color.White;

			return navigationPage;
		}
	}
}