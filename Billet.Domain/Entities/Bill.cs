namespace Billet.Domain.Entities
{
    using Newtonsoft.Json;

    public class Bill
    {
        [JsonProperty("statement")]
        public Statement Statement { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("package")]
        public Package Package { get; set; }

        [JsonProperty("callCharges")]
        public CallCharges CallCharges { get; set; }

        [JsonProperty("skyStore")]
        public SkyStore SkyStore { get; set; }
    }
}