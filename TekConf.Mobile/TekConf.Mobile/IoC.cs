using System;
using Ninject;
using Ninject.Modules;

namespace TekConf.Mobile
{
	public static class AppBase
	{
		public static StandardKernel Container { get; set; }

		public static void Initialize(INinjectModule[] modules)
		{
			var kernel = new StandardKernel(modules);           

			AppBase.Container = kernel;
		}
	}
}