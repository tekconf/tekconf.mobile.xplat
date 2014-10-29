using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using TekConf.Mobile.Controls;
using TekConf.Mobile.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using MonoTouch.CoreLocation;


[assembly:ExportRendererAttribute (typeof(PullToRefreshListView), typeof(PullToRefreshListViewRenderer))]


namespace TekConf.Mobile.iOS
{
	//	public class AddToScheduleButtonRenderer : ButtonRenderer
	//	{
	//		public AddToScheduleButtonRenderer ()
	//		{
	//		}
	//
	//		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
	//		{
	//			base.OnElementChanged (e);
	//
	//			this.SetBackgroundColor (Color.Blue);
	//		}
	//	}
	public class PullToRefreshListViewRenderer : ListViewRenderer
	{
		public PullToRefreshListViewRenderer ()
		{
		}

		private FormsUIRefreshControl refreshControl;

		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			var pullToRefreshListView = (PullToRefreshListView)this.Element;
			var tableView = (UITableView)this.Control;

			refreshControl = new FormsUIRefreshControl ();
			refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			refreshControl.Message = pullToRefreshListView.Message;
			tableView.AddSubview (refreshControl);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			var pullToRefreshListView = (PullToRefreshListView)this.Element;

			if (e.PropertyName == PullToRefreshListView.IsRefreshingProperty.PropertyName) {
				refreshControl.IsRefreshing = pullToRefreshListView.IsRefreshing;
			} else if (e.PropertyName == PullToRefreshListView.MessageProperty.PropertyName) {
				refreshControl.Message = pullToRefreshListView.Message;
			} else if (e.PropertyName == PullToRefreshListView.RefreshCommandProperty.PropertyName) {
				refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			}
		}

	}
}