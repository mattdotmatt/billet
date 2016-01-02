namespace Billet.Common.Entities
{
    using System;
    using Newtonsoft.Json;

    public class Period
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }
    }
}