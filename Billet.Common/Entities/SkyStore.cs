namespace Billet.Common.Entities
{
    using Newtonsoft.Json;

    public class SkyStore
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("rentals")]
        public StoreItem[] Rentals { get; set; }

        [JsonProperty("buyAndKeep")]
        public StoreItem[] BuyAndKeep { get; set; }
    }
}