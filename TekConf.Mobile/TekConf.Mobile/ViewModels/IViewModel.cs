using Xamarin.Forms;
using Ninject;

namespace TekConf.Mobile
{
	public interface IViewModel 
	{
		INavigation Navigation { get; set; }
	}
}