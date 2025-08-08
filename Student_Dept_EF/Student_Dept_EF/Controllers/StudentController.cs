using AutoMapper;
using Student_Dept_EF.DTOs;
using Student_Dept_EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Dept_EF.Controllers
{
   
    public class StudentController : Controller
    {

        Student_Department_DBEntities db = new Student_Department_DBEntities();

        Mapper GetMapper()
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student_Table, studentDTO>()
                   .ForMember(dest => dest.Dept_Name, opt => opt.MapFrom(src => src.Dept_Table.Dept_Name));
                cfg.CreateMap<studentDTO, Student_Table>();  // Reverse map doesn't handle navigation, so define separately
            });

            var mapper = new Mapper(config);
            return mapper;
        }


        // GET: Student
        public ActionResult Index()
        {
            var data = db.Student_Table.Include("Dept_Table").ToList();
            var st = GetMapper().Map<List<studentDTO>>(data);
            return View(st);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(studentDTO s)
        {

            var st = GetMapper().Map<Student_Table>(s);
            db.Student_Table.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var st = db.Student_Table.Find(id);
            return View(st);
        }
    }
}