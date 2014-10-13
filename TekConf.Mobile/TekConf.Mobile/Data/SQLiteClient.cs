using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.Forms;
using TekConf.Mobile.Models;

namespace TekConf.Mobile
{
	public class SQLiteClient
	{
		private static readonly AsyncLock Mutex = new AsyncLock ();
		private readonly SQLiteAsyncConnection _connection;

		[Insights]
		public SQLiteClient ()
		{
			_connection = DependencyService.Get<ISQLite> ().GetConnection ();
			//CreateDatabaseAsync ();
		}
			
		[Insights]
		public async Task CreateDatabaseAsync ()
		{
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				await _connection.CreateTableAsync<Conference> ().ConfigureAwait (false);
				//await _connection.CreateTableAsync<Session> ().ConfigureAwait (false);
			}
		}
			
		[Insights]
		public async Task<List<Conference>> GetConferencesAsync ()
		{
			await CreateDatabaseAsync ();
			List<Conference> conferences = new List<Conference> ();
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				conferences = await _connection.Table<Conference> ().ToListAsync ().ConfigureAwait (false);
			}

			return conferences;
		}
			
		[Insights]
		public async Task Save (Conference conference)
		{
			await CreateDatabaseAsync ();

			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				var existingConference = await _connection.Table<Conference> ()
					.Where (x => x.Slug == conference.Slug)
					.FirstOrDefaultAsync ();

				if (existingConference == null) {
					await _connection.InsertAsync (conference).ConfigureAwait (false);
				} else {
					conference.Id = existingConference.Id;
					await _connection.UpdateAsync (conference).ConfigureAwait (false);
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