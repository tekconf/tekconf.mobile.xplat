namespace TekConf.Mobile
{
	using SQLite.Net.Async;

	public interface ISQLite 
	{
		SQLiteAsyncConnection GetConnection();
	}
}