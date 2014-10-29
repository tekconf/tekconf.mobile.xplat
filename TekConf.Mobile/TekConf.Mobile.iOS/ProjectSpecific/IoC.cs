using Ninject.Modules;
using Xamarin.Forms;

namespace TekConf.Mobile.iOS
{
	public static class IoC
	{
		public static void Initialize()
		{
			var kernel = new Ninject.StandardKernel(new TekConfModule());           

			App.Container = kernel;
		}
	}

	public class TekConfModule : NinjectModule
	{
		public override void Load()
		{

		}
	}
}