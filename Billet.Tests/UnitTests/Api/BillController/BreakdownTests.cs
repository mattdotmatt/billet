namespace Billet.Tests.UnitTests.Api.BillController
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Data.Repositories;
    using FakeItEasy;
    using Models;
    using Service.Services;
    using Xunit;

    public class BillTests : BillControllerContext
    {
        [Fact]
        public void BillShouldBeReturnedWhenAccountExists()
        {
            // ARRANGE
            const long accountId = 123;

            var billingService = A.Fake<IBillingService>();
            IBillRepository billRepository = new BillRepository(billingService);

            A.CallTo(() => billingService.GetBill(accountId)).Returns(SampleBill);

            var sut = BillController(billRepository);

            // ACT
            var response = sut.Breakdown(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            BillBreakdown billModel;
            response.TryGetContentValue(out billModel);

            Assert.NotNull(billModel);
            Assert.Equal(28, billModel.CallCharges.Calls.Length);
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
            var response = sut.Breakdown(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            BillBreakdown billModel;
            response.TryGetContentValue(out billModel);

            Assert.Null(billModel);
        }

        [Fact]
        public void StatusCode500ShouldBeReturnedWhenAnExceptionOccurs()
        {
            // ARRANGE
            const long accountId = 999;

            var billingService = A.Fake<IBillingService>();
            A.CallTo(() => billingService.GetBill(A<long>._)).Throws<Exception>();

            IBillRepository billRepository = new BillRepository(billingService);
            var sut = BillController(billRepository);

            // ACT
            var response = sut.Breakdown(accountId);

            // ASSERT
            A.CallTo(() => billingService.GetBill(accountId)).MustHaveHappened();

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            BillBreakdown billModel;
            response.TryGetContentValue(out billModel);

            Assert.Null(billModel);
        }
    }
}