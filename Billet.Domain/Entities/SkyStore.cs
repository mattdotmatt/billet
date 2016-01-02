namespace Billet.Domain.Entities
{
    using Newtonsoft.Json;

    public class SkyStore
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("rentals")]
        public StoreItem[] Rentals { get; set; }

        [JsonProperty("buyandkeep")]
        public StoreItem[] BuyAndKeep { get; set; }
    }
}