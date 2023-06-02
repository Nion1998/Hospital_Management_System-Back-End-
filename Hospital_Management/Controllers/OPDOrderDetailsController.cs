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
    public class OPDOrderDetailsController : ApiController
    {
        [Route("api/OPDOrderDetails")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OPDOrderDetailsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/OPDOrderDetails/add")]
        [HttpPost]
        public HttpResponseMessage Add(OPDOrderDetailsDTO OPDOrderDetails)
        {
            try
            {
                var data = OPDOrderDetailsService.Add(OPDOrderDetails);
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

        [Route("api/OPDOrderDetails/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = OPDOrderDetailsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }




        [Route("api/OPDOrderDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage OrderView(int id)
        {
            try
            {
                var data = OPDOrderDetailsService.OrderView(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/report")]
        [HttpGet]
        public HttpResponseMessage Report()
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
