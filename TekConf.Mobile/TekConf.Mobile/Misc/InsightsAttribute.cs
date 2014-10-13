using System;
using System.Reflection;
using MethodDecoratorInterfaces;
using System.Diagnostics;
using TekConf.Mobile;
using Xamarin;

[module: Insights]

namespace TekConf.Mobile
{
	[AttributeUsage (AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
	public class InsightsAttribute : Attribute, IMethodDecorator
	{
		private string _methodName;

		public void Init (object instance, MethodBase method, object[] args)
		{
			_methodName = method.DeclaringType.FullName + "." + method.Name;
		}

		public void OnEntry ()
		{
			//_handle = Insights.TrackTime (_methodName);

			var message = string.Format ("OnEntry: {0}", _methodName);
			Insights.Track (message);
			//_handle.Start ();
		}

		public void OnExit ()
		{
			var message = string.Format ("OnExit: {0}", _methodName);
			Insights.Track (message);

//			if (_handle != null) {
//				_handle.Stop ();
//			}
		}

		public void OnException (Exception exception)
		{
			Insights.Report (exception);
		}
	}
}