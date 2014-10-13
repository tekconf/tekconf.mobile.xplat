using Xamarin.Forms;
using Ninject;

namespace TekConf.Mobile
{
	public static class App
	{
		public static StandardKernel Container { get; set; }

		public static string InsightsKey = "768f9b41f49256602c240442a598e946bfdc3d07";

		[Insights]
		public static Page GetMainPage ()
		{
			return new NavigationPage (new ConferencesPage ());
		}
	}
}