using Xamarin.Forms;
using Ninject;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{
	public partial class ConferencePage : TabbedPage
	{
		[Insights]
		public ConferencePage ()
		{
			InitializeComponent ();
		}

		[Insights]
		[Inject]
		public ConferencePage (Conference conference) : this()
		{
			//this.ViewModel.Conference = conference;
			//this.Title = this.ViewModel.Conference.Name;
		}
	}
}