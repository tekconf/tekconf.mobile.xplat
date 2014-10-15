using Xamarin.Forms;
using Ninject;

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
			_viewModel = App.Container.Get<T> ();
			if (_viewModel != null) {
				_viewModel.Navigation = this.Navigation;
				BindingContext = _viewModel;
			}
		}
	}	
}