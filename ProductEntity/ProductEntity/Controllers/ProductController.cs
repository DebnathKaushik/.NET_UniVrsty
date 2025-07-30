using ProductEntity.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductEntity.Controllers
{
    public class ProductController : Controller
    {
        ProductListEntities db = new ProductListEntities();
        // GET: Product
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Fetch the product from DB
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound(); // 404
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Fetch the product from DB
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound(); // 404
            }

            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, string choice)
        {
            if (choice != "Yes") // means no
            {
                return RedirectToAction("Index");
            }
            else  // means yes
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Restock()
        {
            var data = db.Products.ToList();
            return View(data);
        }

    }
}