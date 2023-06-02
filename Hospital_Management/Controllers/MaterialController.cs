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
    public class MaterialController : ApiController
    {
        [Route("api/material")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = MaterialService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/material/add")]
        [HttpPost]
        public HttpResponseMessage Add(MaterialDTO Material)
        {
            try
            {
                var data = MaterialService.Add(Material);
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

        [Route("api/material/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = MaterialService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/material/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(MaterialDTO obj, int id)
        {
            try
            {
                obj.Id = id;
                var data = MaterialService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Up", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/material/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = MaterialService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }
    }
}
