namespace Billet.Domain.Entities
{
    using System;
    using Newtonsoft.Json;

    public class CallCharges
    {
        [JsonProperty("total")]
        public Decimal Total { get; set; }

        [JsonProperty("calls")]
        public Call[] Calls { get; set; }
    }
}