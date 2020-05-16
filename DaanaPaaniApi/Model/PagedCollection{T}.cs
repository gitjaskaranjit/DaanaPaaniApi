using Newtonsoft.Json;
using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class PagedCollection<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Size { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}