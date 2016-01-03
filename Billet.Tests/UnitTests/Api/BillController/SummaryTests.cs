namespace Billet.Tests.UnitTests.Api.BillController
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Controllers.Api;
    using Data.Repositories;
    using FakeItEasy;
    using Models;
    using Service.Services;
    using Xunit;

    public class SummaryTests : BillControllerContext
    {
        [Fact]
        public void AccountSummaryShouldBeReturnedWhenAccountExists()
        {
            // ARRANGE
            const long accountId = 123;

            var billingService = A.Fake<IBillingService>();
            IBillRepository billRepository = new BillRepository(billingService);

            A.CallTo(() => billingService.GetBill(accountId)).Returns(SampleBill);

            var sut = BillController(billRepository);

            // ACT
            var response = sut.Summary(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            BillSummary accountSummaryModel;
            response.TryGetContentValue(out accountSummaryModel);

            Assert.NotNull(accountSummaryModel);
            Assert.Equal(136.03m, accountSummaryModel.Total);
            Assert.Equal(71.40m, accountSummaryModel.PackageTotal);
            Assert.Equal(24.97m, accountSummaryModel.SkyStoreTotal);
            Assert.Equal(59.64m, accountSummaryModel.CallChargesTotal);
            Assert.Equal(new DateTime(2015, 1, 26), accountSummaryModel.From);
            Assert.Equal(new DateTime(2015, 2, 25), accountSummaryModel.To);
        }

        [Fact]
        public void StatusCode404ShouldBeReturnedWhenNoAccountExists()
        {
            // ARRANGE
            const long accountId = 456;

            var billingService = A.Fake<IBillingService>();
            IBillRepository billRepository = new BillRepository(billingService);

            A.CallTo(() => billingService.GetBill(accountId)).Returns("");

            var sut = BillController(billRepository);

            // ACT
            var response = sut.Summary(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            BillSummary accountSummaryModel;
            response.TryGetContentValue(out accountSummaryModel);

            Assert.Null(accountSummaryModel);
        }

        [Fact]
        public void StatusCode500ShouldBeReturnedWhenAnExceptionOccurs()
        {
            // ARRANGE
            const long accountId = 999;

            var billingService = A.Fake<IBillingService>();
            A.CallTo(() => billingService.GetBill(A<long>._)).Throws<Exception>();

            IBillRepository billRepository = new BillRepository(billingService);

            //var sut = AccountController(BillRepository);
            var sut = new BillController(billRepository)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // ACT
            var response = sut.Summary(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            BillSummary accountSummaryModel;
            response.TryGetContentValue(out accountSummaryModel);

            Assert.Null(accountSummaryModel);
        }
    }
}