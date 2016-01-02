namespace Billet
{
    using AutoMapper;
    using Domain.Entities;
    using Models;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Domain.Entities.BillSummary, Models.BillSummary>();

            Mapper.CreateMap<Bill, BillBreakdown>();
        }
    }
}