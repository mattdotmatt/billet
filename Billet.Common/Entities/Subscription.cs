namespace Billet.Common.Entities
{
    using Newtonsoft.Json;

    public class Subscription
    {
        [JsonProperty("type")]
        public SubscriptionType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}