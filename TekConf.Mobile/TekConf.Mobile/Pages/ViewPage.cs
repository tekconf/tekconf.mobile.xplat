using System;
using Xamarin.Forms;
using TekConf.Mobile.ViewModels;

namespace TekConf.Mobile
{
	public class ViewPage<T> : ContentPage where T:IViewModel, new()
	{
		readonly T _viewModel; 

		public T ViewModel
		{
			get {
				return _viewModel;
			}
		}

		public ViewPage ()
		{
			_viewModel = new T ();
			BindingContext = _viewModel;
		}
	}
}