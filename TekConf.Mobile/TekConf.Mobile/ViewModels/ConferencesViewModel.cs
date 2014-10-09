using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin;
using PropertyChanged;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using TekConf.Mobile.Models;
using TekConf.Mobile.Services;
using AutoMapper;
using System.Collections.ObjectModel;


namespace TekConf.Mobile
{
	//	[ImplementPropertyChanged]
	//	public class UserViewModel : IViewModel
	//	{
	//		public string FirstName { get; set; }
	//
	//		public string LastName { get; set; }
	//
	//		public ICommand LoadUser {
	//			get {
	//				return new Command (async () => {
	//					this.FirstName = "John";
	//					this.LastName = "Doe";
	//				});
	//			}
	//		}
	//	}

	[ImplementPropertyChanged]
	public class ConferencesViewModel : IViewModel
	{
		readonly SQLiteClient _db;

		public ConferencesViewModel ()
		{
			_db = new SQLiteClient ();
		}

		public ObservableCollection<Conference> Conferences { get; set; }

		public async Task GetConferences ()
		{
			await GetLocalConferences ();
			await GetRemoteConferences ();
			await GetLocalConferences ();
		}

		private async Task GetLocalConferences ()
		{
			var conferences = await _db.GetConferencesAsync ();
			this.Conferences = new ObservableCollection<Conference>(conferences.OrderBy (x => x.Name).ToList ());
		}

		private async Task GetRemoteConferences ()
		{
			var remoteClient = new TekConfClient ();
			var dtos = await remoteClient.GetConferences ().ConfigureAwait (false);
			var conferences = Mapper.Map<List<Conference>> (dtos);
			await _db.SaveAll (conferences).ConfigureAwait (false);
		}
	}
}