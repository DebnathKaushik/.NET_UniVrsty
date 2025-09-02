using AutoMapper;
using StudentDeptApi.DTOs;
using StudentDeptApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentDeptApi.Controllers
{
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        Student_Dept_APIEntities2 db = new Student_Dept_APIEntities2();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDeptDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // To Get all Department
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = GetMapper().Map<List<DepartmentDTO>>(db.Departments.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }

        // To Create Department
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(DepartmentDTO d)
        {
            var data = GetMapper().Map<Department>(d);
            try
            {
                db.Departments.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
