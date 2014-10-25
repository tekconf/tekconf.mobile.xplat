using System.Threading.Tasks;
using TekConf.Mobile.Models;
using TekConf.Mobile.Controls;
using Xamarin.Forms;

namespace TekConf.Mobile
{
	public class ConferencesPageBase :  ViewPage<ConferencesViewModel>{}

	public partial class ConferencesPage : ConferencesPageBase
	{
		[Insights]
		public ConferencesPage ()
		{
			InitializeComponent ();

			conferencesList.RefreshCommand = this.ViewModel.RefreshCommand;

			Init ();

			this.stack.Children.Add (conferencesList);
			conferencesList.ItemSelected += async (sender, e) => {
				if (e != null && e.SelectedItem != null) {
					var conference = e.SelectedItem as Conference;
					this.ViewModel.SelectConference.Execute (conference);
					conferencesList.SelectedItem = null;
				}
			};
		}

		[Insights]
		private async Task Init ()
		{
			await this.ViewModel.GetConferences ();
		}
	}
}