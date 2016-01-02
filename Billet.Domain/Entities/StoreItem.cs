namespace Billet.Domain.Entities
{
    using System;
    using Newtonsoft.Json;

    public class StoreItem
    {
        [JsonProperty("cost")]
        public Decimal Cost { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }
    }
}