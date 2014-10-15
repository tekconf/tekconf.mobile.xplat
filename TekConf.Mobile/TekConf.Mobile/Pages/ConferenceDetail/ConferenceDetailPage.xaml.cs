using System.Threading.Tasks;
using Ninject;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{	
	public class ConferenceDetailPageBase :  ViewPage<ConferenceViewModel>{}

	public partial class ConferenceDetailPage : ConferenceDetailPageBase
	{
		[Insights]
		public ConferenceDetailPage ()
		{
			InitializeComponent ();

			Init ();
		}

		[Insights]
		[Inject]
		public ConferenceDetailPage (Conference conference) : this()
		{
			this.ViewModel.Conference = conference;
			this.Title = this.ViewModel.Conference.Name;
		}

		[Insights]
		private async Task Init ()
		{
		}
	}
}