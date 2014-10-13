using Xamarin.Forms;
using Ninject;

namespace TekConf.Mobile
{
	public class ViewModelBase : IViewModel
	{
		public INavigation Navigation { get; set; }
	}
	
}