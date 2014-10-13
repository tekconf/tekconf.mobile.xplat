using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using TekConf.Mobile.Models;
using TekConf.Mobile.Services;
using AutoMapper;
using System.Collections.ObjectModel;
using Ninject;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TekConf.Mobile
{
	[ImplementPropertyChanged]
	public class ConferencesViewModel : ViewModelBase
	{
		private readonly SQLiteClient _db;

		public ConferencesViewModel () {}

		[Inject]
		[Insights]
		public ConferencesViewModel (SQLiteClient client)
		{
			_db = client;
		}

		public ObservableCollection<Conference> Conferences { get; set; }

		public bool IsLoading { get; set; }

		public ICommand SelectConference {
			get {
				return new Command<Conference> (async (conference) => {
					await Navigation.PushAsync(new ConferencePage(conference));
				});
			}
		}

		[Insights]
		public async Task GetConferences ()
		{
			this.IsLoading = true;
			//throw new ArgumentException ("Testing getconferences");

			await GetLocalConferences ();
			await GetRemoteConferences ();
			await GetLocalConferences ();

			this.IsLoading = false;
		}

		[Insights]
		private async Task GetLocalConferences ()
		{
			var conferences = await _db.GetConferencesAsync ();
			this.Conferences = new ObservableCollection<Conference> (conferences.OrderBy (x => x.Name).ToList ());
		}

		[Insights]
		private async Task GetRemoteConferences ()
		{
			var remoteClient = new TekConfClient ();
			var dtos = await remoteClient.GetConferences ().ConfigureAwait (false);
			var conferences = Mapper.Map<List<Conference>> (dtos);
			await _db.SaveAll (conferences).ConfigureAwait (false);
		}
	}
}