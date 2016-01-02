namespace Billet.Domain.Entities
{
    using System;
    using Newtonsoft.Json;

    public class Statement
    {
        [JsonProperty("generated")]
        public DateTime Generated { get; set; }

        [JsonProperty("due")]
        public DateTime Due { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }
    }
}