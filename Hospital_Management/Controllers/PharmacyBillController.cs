using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hospital_Management.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PharmacyBillController : ApiController
    {
        [Route("api/PharmacyBill")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PharmacyBillingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/PharmacyBilling/add")]
        [HttpPost]
        public HttpResponseMessage Add(PharmacyBillingDTO PharmacyBilling)
        {
            try
            {
                var data = PharmacyBillingService.Add(PharmacyBilling);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        

    }
}
