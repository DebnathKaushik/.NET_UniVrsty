using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
        Zero_HungerEntities6 db = new Zero_HungerEntities6();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RestaurantLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestaurantLogin(string name,string pass)
        {
            // Restaurant exist or Not
            var restaurant = (from u in db.Restaurants
                        where
                       u.Restaurant_Name.Equals(name) &&
                       u.restaurant_Pass.Equals(pass)
                        select u).SingleOrDefault();
            if (restaurant != null)
            {
                Session["Restaurant_Id"] = restaurant.Restaurant_Id;
                Session["Restaurant_Name"] = restaurant.Restaurant_Name;

                return RedirectToAction("Index","Restaurant");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }

        }

    }
}