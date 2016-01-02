namespace Billet.Controllers.Api
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data.Repositories;
    using Domain.Entities;
    using Models;

    public class BillController : ApiController
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [Route("api/account/{id}/billsummary"), HttpGet]
        public HttpResponseMessage Summary(long id)
        {
            try
            {
                var summary = _billRepository.GetSummary(id);

                return summary == null ? NotFoundResponse(string.Format("No account found for {0}", id)) : SummaryResponse(summary);
            }
            catch (Exception)
            {
                return ErrorResponse("Error");
            }
        }

        [Route("api/account/{id}/billbreakdown"), HttpGet]
        public HttpResponseMessage Breakdown(long id)
        {
            try
            {
                var bill = _billRepository.GetBill(id);

                return bill == null ? NotFoundResponse(string.Format("No account found for {0}", id)) : BillResponse(bill);
            }
            catch (Exception)
            {
                return ErrorResponse("Error");
            }
        }

        private HttpResponseMessage SummaryResponse(Domain.Entities.BillSummary summary)
        {
            var model = AutoMapper.Mapper.Map<Models.BillSummary>(summary);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        private HttpResponseMessage BillResponse(Bill bill)
        {
            var model = AutoMapper.Mapper.Map<BillBreakdown>(bill);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        private HttpResponseMessage ErrorResponse(string message)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
        }

        private HttpResponseMessage NotFoundResponse(string message)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
        }
    }
}