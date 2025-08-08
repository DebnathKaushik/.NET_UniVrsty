using Student_Dept_EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Dept_EF.Controllers
{
    public class DepartmentController : Controller
    {
        Student_Department_DBEntities db = new Student_Department_DBEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Dept_Table.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dept_Table d)
        {
            db.Dept_Table.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            var dept = (from d in db.Dept_Table.Include("Student_Table")
                        where d.Dept_Id == id
                        select d).SingleOrDefault();
            return View(dept);
        }
    }
}