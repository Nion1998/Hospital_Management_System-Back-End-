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
    public class PharmacyOrderDetailsController : ApiController
    {
        [Route("api/PharmacyOrderDetails")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PharmacyOrderDetailsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/PharmacyOrderDetails/add")]
        [HttpPost]
        public HttpResponseMessage Add(PharmacyOrderDetailsDTO PharmacyOrderDetails)
        {
            try
            {
                var data = PharmacyOrderDetailsService.Add(PharmacyOrderDetails);
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

        [Route("api/PharmacyOrderDetails/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PharmacyOrderDetailsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }




        [Route("api/PharmacyOrderDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage OrderView(int id)
        {
            try
            {
                var data = PharmacyOrderDetailsService.OrderView(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/r")]
        [HttpGet]
        public HttpResponseMessage report()
        {
            try
            {
                var data = PharmacyBillRiportService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
