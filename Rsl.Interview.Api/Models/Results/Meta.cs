using Newtonsoft.Json;
using System;

namespace Rsl.Interview.Api.Models.Results
{
    public class Meta
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("stems")]
        public string[] Stems { get; set; }

        [JsonProperty("offensive")]
        public bool Offensive { get; set; }
    }
}
