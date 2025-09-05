using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;


namespace PresentationApi.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = StudentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("sch")]
        public HttpResponseMessage GetSch()
        {
            var data = StudentService.GetSch();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            var data = StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            var result = StudentService.Delete(id); 
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
        }
    }
}