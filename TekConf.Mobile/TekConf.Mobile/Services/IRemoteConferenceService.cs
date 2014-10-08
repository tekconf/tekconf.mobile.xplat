using System;
using System.Threading.Tasks;
using TekConf.Mobile.Dtos;
using System.Collections.Generic;

namespace TekConf.Mobile
{
	public interface IRemoteConferenceService
	{
		Task<IEnumerable<ConferenceDto>> GetConferences();
	}
	
}
