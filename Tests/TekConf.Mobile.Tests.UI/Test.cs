using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;
using Xamarin.UITest.iOS;
using Xamarin.UITest;

namespace TekConf.Mobile.Tests.UI
{
	[TestFixture ()]
	public class Test
	{
		public string PathToIPA { get; set; }
		iOSApp _app;

		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			FileInfo fi = new FileInfo(currentFile);
			string dir = fi.Directory.Parent.Parent.Parent.Parent.FullName;
			PathToIPA = Path.Combine(dir, "TekConf.Mobile.iOS", "bin", "iPhoneSimulator", "Debug", "TekConfMobileiOS.app");
		}

		[SetUp]
		public void SetUp()
		{
			_app = ConfigureApp.iOS.AppBundle(PathToIPA).StartApp();
		}

		[Test ()]
		public void TestCase ()
		{
			var result = _app.Query(x => x.Text("Evolve"));
			Assert.IsNotNull (result);
		}
	}
}