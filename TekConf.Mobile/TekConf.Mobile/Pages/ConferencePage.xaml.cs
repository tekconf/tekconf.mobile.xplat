using System.Threading.Tasks;
using Ninject;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{	
	public partial class ConferencePage : ConferencePageBase
	{
		[Insights]
		public ConferencePage ()
		{
			InitializeComponent ();

			Init ();
		}
			
		[Insights]
		[Inject]
		public ConferencePage (Conference conference) : this()
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