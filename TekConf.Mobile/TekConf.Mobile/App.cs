using Xamarin.Forms;
using Xamarin;

namespace TekConf.Mobile
{
	public static class App
	{
		private const string insightsKey = "768f9b41f49256602c240442a598e946bfdc3d07";

		public static Page GetMainPage()
		{
			Insights.Initialize(insightsKey);
			Insights.Track ("Page.GetMainPage");



			return new ConferencesPage ();
		}
	}
}