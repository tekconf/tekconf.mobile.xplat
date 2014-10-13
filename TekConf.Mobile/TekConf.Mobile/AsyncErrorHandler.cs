using System;
using System.Diagnostics;
using Xamarin;

namespace TekConf.Mobile
{
	public static class AsyncErrorHandler
	{
		public static void HandleException(Exception exception)
		{
			Debug.WriteLine("Exception caught" + exception);
			Insights.Report (exception);
		}
	}
}