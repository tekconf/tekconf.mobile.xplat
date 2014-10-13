using System.Threading.Tasks;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{
	public partial class ConferencesPage : ConferencesPageBase
	{
		[Insights]
		public ConferencesPage ()
		{
			InitializeComponent ();

			Init ();

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