using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DaanaPaaniApi.DTOs
{
    public partial class GeocodeResponse
    {
        [JsonProperty("items")]
        public Result[] Items { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("resultType")]
        public string ResultType { get; set; }

        [JsonProperty("houseNumberType")]
        public string HouseNumberType { get; set; }

        [JsonProperty("address")]
        public GeoAddress Address { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("access")]
        public Position[] Access { get; set; }

        [JsonProperty("mapView")]
        public MapView MapView { get; set; }

        [JsonProperty("scoring")]
        public Scoring Scoring { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("lat")]
        public Double Lat { get; set; }

        [JsonProperty("lng")]
        public Double Lng { get; set; }
    }

    public partial class GeoAddress
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("houseNumber")]
        public long HouseNumber { get; set; }
    }

    public partial class MapView
    {
        [JsonProperty("west")]
        public double West { get; set; }

        [JsonProperty("south")]
        public double South { get; set; }

        [JsonProperty("east")]
        public double East { get; set; }

        [JsonProperty("north")]
        public double North { get; set; }
    }

    public partial class Scoring
    {
        [JsonProperty("queryScore")]
        public double QueryScore { get; set; }

        [JsonProperty("fieldScore")]
        public FieldScore FieldScore { get; set; }
    }

    public partial class FieldScore
    {
        [JsonProperty("city")]
        public long City { get; set; }

        [JsonProperty("streets")]
        public double[] Streets { get; set; }

        [JsonProperty("houseNumber")]
        public long HouseNumber { get; set; }
    }
}