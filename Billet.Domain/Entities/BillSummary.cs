namespace Billet.Domain.Entities
{
    using System;

    public class BillSummary
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public decimal Total { get; set; }

        public decimal PackageTotal { get; set; }
        public decimal CallChargesTotal { get; set; }
        public decimal SkyStoreTotal { get; set; }
    }
}