using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("news/all")]
        public HttpResponseMessage Get()
        {
            var data = NewsService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("news/{id}")]
        public HttpResponseMessage Get(int Id)
        {
            var data = NewsService.GetNewsbyId(Id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("news/category/{CName}")]
        public HttpResponseMessage Get(string CName) 
        {
            var data = NewsService.GetNewsbyCatagoryName(CName);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }




    }
}
