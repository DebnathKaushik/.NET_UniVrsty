using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    [RoutePrefix("api")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("all-student")]
        public HttpResponseMessage get_all_student()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Get all the Student");
        }

        [HttpPost]
        [Route("student-create")]
        public HttpResponseMessage create_student()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "create Student");
        }

        [HttpDelete]
        [Route("student-delete/{id}")]
        public HttpResponseMessage delete_student(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Student: "+id);
        }

        [HttpGet]
        [Route("student/{id}")]
        public IHttpActionResult Specific_student(int id)
        {
            return Ok("Student id: "+id);
        }

    }
}
