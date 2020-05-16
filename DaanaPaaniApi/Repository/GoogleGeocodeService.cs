using DaanaPaaniApi.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class GoogleGeocodeService : IGoogleGeocode

    {
        private readonly IHttpClientFactory _client;
        private readonly GoogleApiOptions _googleApiOptions;
        public bool error { get; set; }

        public GoogleGeocodeService(IHttpClientFactory client, IOptions<GoogleApiOptions> googleApiOptionsWrapper)
        {
            _client = client;
            _googleApiOptions = googleApiOptionsWrapper.Value;
        }

        public async Task<GeocodeResponse> GetLocationInfoAsync(Address address)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                                                _googleApiOptions.GeocodeBaseUrl
                                                + address.StreetNo + "+"
                                                + address.StreetName + "+"
                                                + address.City + "&key="
                                                + _googleApiOptions.key);

            var client = _client.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var jsonResult = JsonConvert.DeserializeObject<GeocodeResponse>(result);
                if (jsonResult.Status.Equals("ZERO_RESULTS") | string.IsNullOrWhiteSpace(address.StreetName) | address.StreetNo.Equals(0))
                {
                    this.error = true;
                    throw new ArgumentException("Please check your address");
                }
                if (jsonResult.Status.Equals("REQUEST_DENIED"))
                {
                    this.error = true;
                    throw new ArgumentException("check your api key https://developers.google.com/maps/documentation/embed/get-api-key");
                }
                return jsonResult;
            }
            else
            {
                this.error = true;
                throw new Exception("Geocode request failed");
            }
        }
    }
}