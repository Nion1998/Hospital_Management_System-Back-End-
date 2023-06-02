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
    public class CustomerOPDController : ApiController
    {
            [Route("api/CustomerOPD")]
            [HttpGet]
            public HttpResponseMessage Get()
            {
                try
                {
                    var data = CustomerOPDService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [Route("api/CustomerOPD/add")]
            [HttpPost]
            public HttpResponseMessage Add(CustomerOPDDTO CustomerOPD)
            {
                try
                {
                    var data = CustomerOPDService.Add(CustomerOPD);
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

            [Route("api/CustomerOPD/delete/{id}")]
            [HttpGet]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = CustomerOPDService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }


            }

            [Route("api/CustomerOPD/update/{id}")]
            [HttpPost]
            public HttpResponseMessage Update(CustomerOPDDTO obj, int id)
            {
                try
                {
                    obj.Id = id;
                    var data = CustomerOPDService.Update(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Up", data });
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }

            }

            [Route("api/CustomerOPD/{id}")]
            [HttpGet]
            public HttpResponseMessage Get(int id)
            {
                try
                {
                    var data = CustomerOPDService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
        }
}
