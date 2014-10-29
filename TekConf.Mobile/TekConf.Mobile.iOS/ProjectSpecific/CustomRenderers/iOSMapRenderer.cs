#region usings
using Xamarin.Forms;
using TekConf.Mobile.iOS;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using MonoTouch.CoreLocation;
using MonoTouch.ObjCRuntime;
#endregion

[assembly:ExportRendererAttribute (typeof(Map), typeof(iOSMapRenderer))]

namespace TekConf.Mobile.iOS
{
	public class iOSMapRenderer : MapRenderer
	{
		CLLocationManager _locationManager;

		public iOSMapRenderer ()
		{
			_locationManager = new CLLocationManager();

			if (_locationManager.RespondsToSelector (new Selector ("requestWhenInUseAuthorization"))) {
				_locationManager.RequestWhenInUseAuthorization ();
			}
		}

		protected override void OnElementChanged (Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			_locationManager = new CLLocationManager();

			if (_locationManager.RespondsToSelector (new Selector ("requestWhenInUseAuthorization"))) {
				_locationManager.RequestWhenInUseAuthorization ();
			}
		}
	}
}