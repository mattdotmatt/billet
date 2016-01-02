namespace Billet.Models
{
    using Domain.Entities;
    using Newtonsoft.Json;

    public class BillBreakdown
    {
        [JsonProperty("package")]
        public Package Package { get; set; }

        [JsonProperty("callcharges")]
        public CallCharges CallCharges { get; set; }

        [JsonProperty("skystore")]
        public SkyStore SkyStore { get; set; }
    }
}