#region usings
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyChanged;
using TekConf.Mobile.Models;
using TekConf.Mobile.Services;
using Ninject;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Akavache;
using System.Reactive.Linq;
using System.Diagnostics;
#endregion

namespace TekConf.Mobile
{
	[ImplementPropertyChanged]
	public class ConferencesViewModel : ViewModelBase
	{
		private readonly SQLiteClient _db;

		public ConferencesViewModel ()
		{
		}

		[Inject]
		[Insights]
		public ConferencesViewModel (SQLiteClient client)
		{
			_db = client;
		}

		public List<Conference> Conferences { get; set; }

		public bool IsLoading { get; set; }

		public ICommand SelectConference {
			get {
				return new Command<Conference> (async (conference) => {
					await Navigation.PushAsync (new ConferenceDetailPage (conference));
				});
			}
		}

		[Insights]
		public async Task GetConferences ()
		{
			var cache = BlobCache.LocalMachine;
			var conferences = cache.GetAndFetchLatest ("conferences", GetRemoteConferences, offset => {
				TimeSpan elapsed = DateTimeOffset.Now - offset;
				return elapsed > new TimeSpan (hours: 0, minutes: 0, seconds: 10);
			});

			this.Conferences = await conferences.FirstOrDefaultAsync ();
		}

		private async Task<List<Conference>> GetRemoteConferences ()
		{
			this.IsLoading = true;
			var remoteClient = new TekConfClient ();
			List<Conference> conferences = await remoteClient.GetConferences ().ConfigureAwait (false);
			await _db.SaveAll (conferences).ConfigureAwait (false);

			Debug.WriteLine ("returning conferences");

			this.IsLoading = false;

			return conferences;
		}
			
		private Command _refreshCommand;
		public Command RefreshCommand
		{
			get 
			{ 
				return _refreshCommand ?? 
						(
							_refreshCommand = new Command (async ()=> await GetConferences())
						); 
			}
		}
	}
}