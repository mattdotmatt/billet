namespace Billet.Common.Entities
{
    using System;
    using Newtonsoft.Json;

    public class Call
    {
        [JsonProperty("called")]
        public string Called { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty("cost")]
        public Decimal Cost { get; set; }
    }
}