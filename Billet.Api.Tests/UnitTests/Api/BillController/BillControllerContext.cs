using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Billet.Tests.UnitTests.Api.BillController
{
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using Controllers.Api;
    using Data.Repositories;

    public class BillControllerContext
    {
        public readonly string SampleBill;

        public BillControllerContext()
        {
            AutoMapperConfig.RegisterMappings();
            var currentAssembly = Assembly.GetExecutingAssembly();

            using (var stream = currentAssembly.GetManifestResourceStream("Billet.Tests.UnitTests.Api.sample-bill.json"))
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        SampleBill = reader.ReadToEnd();
                    }

        }

        public BillController BillController(IBillRepository billRepository)
        {
            var sut = new BillController(billRepository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            return sut;
        }

    }
}