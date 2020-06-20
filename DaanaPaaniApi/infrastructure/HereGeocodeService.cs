using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class HereGeocodeService : IGeocodeService
    {
        private readonly IHttpClientFactory _client;
        private readonly HereApiOptions _options;
        public bool Error { get; set; }
        public HereGeocodeService(IHttpClientFactory client,IOptions<HereApiOptions> optionsWrapper)
        {
            _client = client;
            _options = optionsWrapper.Value;

        }

        public  async Task<GeocodeResponse> GetLocationInfoAsync(Model.Address address)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                                                _options.GeocodeBaseUrl
                                                + address.StreetNo + "+"
                                                + address.StreetName + "+"
                                                + address.City + "&apiKey="
                                                + _options.HereApikey);


            var client = _client.CreateClient();

            if (string.IsNullOrWhiteSpace(address.StreetName) | address.StreetNo.Equals(0))
            {
                this.Error = true;
                throw new ArgumentException("Please check your address");
            }
            else
            {

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                   var JsonResult =  JsonConvert.DeserializeObject<GeocodeResponse>(result);
                   this.Error = !JsonResult.Items.Any();
                    return JsonResult;
                }
                else
                {
                    throw new ArgumentException("Something went wrong while fetching geocode!");
                }
            }
        }
    }
}
