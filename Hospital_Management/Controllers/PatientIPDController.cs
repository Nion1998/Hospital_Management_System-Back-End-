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
    public class PatientIPDController : ApiController
    {
        [Route("api/patientIPD")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PatientIPDService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/patientIPD/add")]
        [HttpPost]
        public HttpResponseMessage Add(PatientIPDDTO PatientIPD)
        {
            try
            {
                var data = PatientIPDService.Add(PatientIPD);
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

        [Route("api/patientIPD/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PatientIPDService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/patientIPD/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(PatientIPDDTO obj, int id)
        {
            try
            {
                obj.Id = id;
                var data = PatientIPDService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Up", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/patientIPD/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PatientIPDService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
