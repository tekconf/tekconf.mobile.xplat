using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.Forms;
using TekConf.Mobile.Models;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Exceptions;
using SQLite.Net;

namespace TekConf.Mobile
{
	public class SQLiteClient
	{
		private static readonly AsyncLock Mutex = new AsyncLock ();
		private readonly SQLiteAsyncConnection _asyncConnection;
		private readonly SQLiteConnection _syncConnection;

		[Insights]
		public SQLiteClient ()
		{
			var sqlite = DependencyService.Get<ISQLite> ();
			_asyncConnection = sqlite.GetAsyncConnection ();
			_syncConnection = sqlite.GetSyncConnection ();
			//CreateDatabaseAsync ();
		}

		[Insights]
		public async Task CreateDatabaseAsync ()
		{
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				await _asyncConnection.CreateTableAsync<Conference> ().ConfigureAwait (false);
				await _asyncConnection.CreateTableAsync<Session> ().ConfigureAwait (false);
				await _asyncConnection.CreateTableAsync<Speaker> ().ConfigureAwait (false);
				await _asyncConnection.CreateTableAsync<SessionSpeaker> ().ConfigureAwait (false);
			}
		}

		[Insights]
		public async Task<List<Conference>> GetConferencesAsync ()
		{
			await CreateDatabaseAsync ();
			List<Conference> conferences = new List<Conference> ();
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				conferences = await Task.Run (() => _syncConnection.GetAllWithChildren<Conference> ()).ConfigureAwait (false);
				//conferences = await _asyncConnection.Table<Conference> ().ToListAsync ().ConfigureAwait (false);
			}

			return conferences;
		}

		[Insights]
		public async Task Save (Conference conference)
		{
			await CreateDatabaseAsync ();

			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				var existingConference = await _asyncConnection.Table<Conference> ()
					.Where (x => x.Slug == conference.Slug)
					.FirstOrDefaultAsync ();

				if (existingConference == null) {
					await Task.Run (() => _syncConnection.InsertWithChildren (conference)).ConfigureAwait (false);
					foreach (var session in conference.Sessions) {
						foreach (var speaker in session.Speakers) {
							speaker.Session = session;
							speaker.SessionId = session.Id;
							await Task.Run (() => _syncConnection.Insert (speaker)).ConfigureAwait (false);
						}
					}
				
				} else {
					conference.Id = existingConference.Id;
					await Task.Run (() => _syncConnection.InsertOrReplaceWithChildren (conference)).ConfigureAwait (false);
					foreach (var session in conference.Sessions) {
						foreach (var speaker in session.Speakers) {
							speaker.Session = session;
							speaker.SessionId = session.Id;
							await Task.Run (() => _syncConnection.InsertOrReplace (speaker)).ConfigureAwait (false);
						}
					}
				}
			}
		}

		[Insights]
		public async Task SaveAll (IEnumerable<Conference> conferences)
		{
			await CreateDatabaseAsync ();

			foreach (var conference in conferences) {
				//throw new ArgumentException ("Async error");

				await Save (conference);
			}
		}
	}
}