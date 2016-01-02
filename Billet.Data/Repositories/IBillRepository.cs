namespace Billet.Data.Repositories
{
    using Domain.Entities;

    public interface IBillRepository
    {
        BillSummary GetSummary(long accountId);
        Bill GetBill(long accountId);
    }
}