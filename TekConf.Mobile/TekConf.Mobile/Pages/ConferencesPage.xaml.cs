using System.Threading.Tasks;

namespace TekConf.Mobile
{
	public class ConferencesPageBase :  ViewPage<ConferencesViewModel> {}

	public partial class ConferencesPage : ConferencesPageBase
	{
		public ConferencesPage ()
		{
			InitializeComponent ();

			Init ();
		}
	
		private async Task Init ()
		{
			await this.ViewModel.GetConferences ();
		}
	}

}