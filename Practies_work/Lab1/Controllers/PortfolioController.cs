using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        { 
            
     
            return View();
        }

        public ActionResult Education()
        {
            ViewBag.Message = "Your Education page.";
            return View();
        }

        public ActionResult Project()
        {
            ViewBag.Message = "Your Project page.";
            return View();
        }
    }
}