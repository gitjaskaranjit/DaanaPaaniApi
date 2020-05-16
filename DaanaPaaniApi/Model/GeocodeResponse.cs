using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaanaPaaniApi.Model
{
    public partial class GeocodeResponse
    {
        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("access_points")]
        public object[] AccessPoints { get; set; }

        [JsonProperty("address_components")]
        public AddressComponent[] AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public partial class AddressComponent
    {
        [JsonProperty("long_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LongName { get; set; }

        [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Types { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        public class Location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }
    }
}