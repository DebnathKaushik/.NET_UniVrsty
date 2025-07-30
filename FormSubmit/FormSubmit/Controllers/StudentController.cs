using FormSubmit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmit.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View(new Student());
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Home");

            }

            
            return View(s);
        }
       
        
    }
}