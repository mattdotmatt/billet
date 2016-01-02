namespace Billet.Common.Entities
{
    using Newtonsoft.Json;

    public class Package
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("subscriptions")]
        public Subscription[] Subscriptions { get; set; }
    }
}