using Xamarin.Forms;
using DtoToVM.Android.Data;
using System;
using DtoToVM.Data;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;

[assembly: Dependency (typeof(SQLiteClient))]
namespace TekConf.Mobile.Android.Data
{
	public class SQLiteClient : ISQLite
	{
		public SQLiteAsyncConnection GetConnection ()
		{
			var sqliteFilename = "Conferences.db3";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);

			var path = Path.Combine (documentsPath, sqliteFilename);

			var platform = new SQLitePlatformAndroid ();

			var connectionWithLock = new SQLiteConnectionWithLock (
				                         platform,
				                         new SQLiteConnectionString (path, true));

			var connection = new SQLiteAsyncConnection (() => connectionWithLock);

			return connection;
		}
	}
}