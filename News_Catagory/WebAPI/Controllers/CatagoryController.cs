using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class CatagoryController : ApiController
    {
        [HttpPatch]
        [Route("catagory/update/{id}")]
        public HttpResponseMessage update(int id, CatagoryDTO c)
        {
             
            c.Id = id;

            var data = CatagoryService.updateCatagory(c);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Catagory updated successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Catagory not found");

        }

        [HttpDelete]
        [Route("catagory/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            var data = CatagoryService.deleteCatagory(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Catagory not found");
        }
    }
}
