namespace Billet.Models
{
    using System;
    using Newtonsoft.Json;

    public class BillSummary
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("packagetotal")]
        public decimal PackageTotal { get; set; }

        [JsonProperty("skystoretotal")]
        public decimal SkyStoreTotal { get; set; }

        [JsonProperty("callchargestotal")]
        public decimal CallChargesTotal { get; set; }
    }
}