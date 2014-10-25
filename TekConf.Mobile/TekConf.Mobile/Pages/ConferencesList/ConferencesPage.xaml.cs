using TekConf.Mobile.Models;

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

			this.stack.Children.Add (conferencesList);

			conferencesList.ItemSelected += async (sender, e) => {
				if (e != null && e.SelectedItem != null) {
					var conference = e.SelectedItem as Conference;
					this.ViewModel.SelectConference.Execute (conference);
					conferencesList.SelectedItem = null;
				}
			};
		}
	}
}