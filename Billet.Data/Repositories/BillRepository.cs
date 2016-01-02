namespace Billet.Data.Repositories
{
    using Domain.Entities;
    using Newtonsoft.Json;
    using Service.Services;

    public class BillRepository : IBillRepository
    {
        private readonly IBillingService _billingService;

        public BillRepository(IBillingService billingService)
        {
            _billingService = billingService;
        }

        public BillSummary GetSummary(long accountId)
        {
            var billJson = _billingService.GetBill(accountId);

            if (string.IsNullOrEmpty(billJson)) return null;

            var bill = JsonConvert.DeserializeObject<Bill>(billJson);

            return new BillSummary
            {
                From = bill.Statement.Period.From,
                To = bill.Statement.Period.To,
                Total = bill.Total,
                PackageTotal = bill.Package.Total,
                SkyStoreTotal = bill.SkyStore.Total,
                CallChargesTotal = bill.CallCharges.Total
            };
        }

        public Bill GetBill(long accountId)
        {
            var billJson = _billingService.GetBill(accountId);

            return string.IsNullOrEmpty(billJson) ? null 
                                                  : JsonConvert.DeserializeObject<Bill>(billJson);
        }
    }
}