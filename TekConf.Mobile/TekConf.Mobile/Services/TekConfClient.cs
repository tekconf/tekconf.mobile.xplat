using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using ModernHttpClient;

namespace TekConf.Mobile.Services
{
	public class TekConfClient
	{
		[Insights]
		public async Task<List<Models.Conference>> GetConferences ()
		{
			IEnumerable<Dtos.Conference> conferenceDtos = Enumerable.Empty<Dtos.Conference> ();
			IEnumerable<Models.Conference> conferences = Enumerable.Empty<Models.Conference> ();

			using (var httpClient = CreateClient ()) {
				var response = await httpClient.GetAsync ("conferences?showPastConferences=true").ConfigureAwait (false);
				//var response = await httpClient.GetAsync ("conferences").ConfigureAwait (false);

				if (response.IsSuccessStatusCode) {
					var json = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
					if (!string.IsNullOrWhiteSpace (json)) {
						conferenceDtos = await Task.Run (() => 
							JsonConvert.DeserializeObject<IEnumerable<Dtos.Conference>> (json)
						).ConfigureAwait (false);

						conferences = await Task.Run (() => 
							Mapper.Map<IEnumerable<Models.Conference>> (conferenceDtos)
						).ConfigureAwait (false);
					}
				}
			}
				
			return conferences.ToList ();
		}

		private const string ApiBaseAddress = "http://api.tekconf.com/v1/";

		[Insights]
		private HttpClient CreateClient ()
		{
			var httpClient = new HttpClient (new NativeMessageHandler ()) { 
				BaseAddress = new Uri (ApiBaseAddress)
			};

			httpClient.DefaultRequestHeaders.Accept.Clear ();
			httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

			return httpClient;
		}
	}
}