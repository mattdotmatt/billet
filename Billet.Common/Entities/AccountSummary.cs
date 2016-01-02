namespace Billet.Common.Entities
{
    using System;

    public class AccountSummary
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public decimal Total { get; set; }

        public decimal PackageTotal { get; set; }
        public decimal CallChargesTotal { get; set; }
        public decimal SkyStoreTotal { get; set; }
    }
}