using SQLite.Net;

namespace TekConf.Mobile
{
	using SQLite.Net.Async;

	public interface ISQLite 
	{
		SQLiteAsyncConnection GetAsyncConnection();
		SQLiteConnection GetSyncConnection();
	}
}