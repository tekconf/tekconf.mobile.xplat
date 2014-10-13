using PropertyChanged;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{
	[ImplementPropertyChanged]
	public class ConferenceViewModel : ViewModelBase
	{
		public Conference Conference { get; set; }
	}
}