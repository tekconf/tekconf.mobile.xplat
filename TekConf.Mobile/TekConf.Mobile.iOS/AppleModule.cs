using System;
using Ninject;
using Ninject.Modules;

namespace TekConf.Mobile.iOS
{
	public class NinjectDemoModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IGlobalSettings>().To<ApplePlatform>();
			//this.Bind<ISettings> ().To<AppleSettings> ();
		}
	}
}