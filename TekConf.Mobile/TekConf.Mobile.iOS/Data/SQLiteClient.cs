using Xamarin.Forms;
using TekConf.Mobile.iOS.Data;
using System;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net;

[assembly: Dependency (typeof(SQLiteClient))]
namespace TekConf.Mobile.iOS.Data
{
	public class SQLiteClient : ISQLite
	{
		public SQLiteAsyncConnection GetConnection ()
		{
			const string sqliteFilename = "Conferences.db3";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine (documentsPath, "..", "Library");
			var path = Path.Combine (libraryPath, sqliteFilename);

			var platform = new SQLitePlatformIOS ();

			var connectionWithLock = new SQLiteConnectionWithLock (
				                         platform,
				                         new SQLiteConnectionString (path, true));

			var connection = new SQLiteAsyncConnection (() => connectionWithLock);

			return connection;
		}
	}
}