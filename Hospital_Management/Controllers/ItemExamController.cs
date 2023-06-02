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
    public class ItemExamController : ApiController
    {
        [Route("api/itemexam")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ItemExamService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/itemexam/add")]
        [HttpPost]
        public HttpResponseMessage Add(ItemExamDTO ItemExam)
        {
            try
            {
                var data = ItemExamService.Add(ItemExam);
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

        [Route("api/itemexam/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ItemExamService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Delete", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/itemexam/update/{id}")]
        [HttpPost]
        public HttpResponseMessage Update(ItemExamDTO obj, int id)
        {
            try
            {
                obj.Id = id;
                var data = ItemExamService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Up", data });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/itemexam/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ItemExamService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [Route("api/itemexam/search")]
        [HttpPost]
        public HttpResponseMessage Msearch(ItemExamDTO obj)
        {
            try
            {
                var data = ItemExamService.Msearch(obj.Name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }
    }
}
