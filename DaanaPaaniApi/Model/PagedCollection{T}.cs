using Newtonsoft.Json;
using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class PagedCollection<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSize { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}