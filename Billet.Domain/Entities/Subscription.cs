namespace Billet.Domain.Entities
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Subscription
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}