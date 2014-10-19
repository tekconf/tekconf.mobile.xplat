using System.Threading.Tasks;
using Ninject;
using TekConf.Mobile.Models;
using Xamarin.Forms.Maps;

namespace TekConf.Mobile
{
	public class ConferenceDetailPageBase :  ViewPage<ConferenceViewModel> {}

	public partial class ConferenceDetailPage : ConferenceDetailPageBase
	{
		[Insights]
		public ConferenceDetailPage ()
		{
			InitializeComponent ();

			Init ();
		}

		[Insights]
		[Inject]
		public ConferenceDetailPage (Conference conference) : this ()
		{
			this.ViewModel.Conference = conference;
			this.Title = this.ViewModel.Conference.Name;

			SetMap ();
		}

		[Insights]
		private async Task Init ()
		{
		}

		private void SetMap ()
		{
			if (this.ViewModel.Conference != null
			    && this.ViewModel.Conference.Latitude.HasValue
			    && this.ViewModel.Conference.Longitude.HasValue) {


				var position = new Position (
					this.ViewModel.Conference.Latitude.Value, 
					this.ViewModel.Conference.Longitude.Value
				);

				var pin = new Pin {
					Type = PinType.Place,
					Position = position,
					Label = this.ViewModel.Conference.Location ?? this.ViewModel.Conference.Name,
					Address = this.ViewModel.Conference.FormattedAddress
				};

				conferenceLocationMap.Pins.Add(pin);

				conferenceLocationMap.MoveToRegion 
				(
					MapSpan.FromCenterAndRadius
					(
						new Position (
							this.ViewModel.Conference.Latitude.Value, 
							this.ViewModel.Conference.Longitude.Value
						), Distance.FromMiles (1)
					)
				);
			}
		}

	}
}