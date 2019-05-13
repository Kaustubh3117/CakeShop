using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CakeShop.Models;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private CakeShopEntities db = new CakeShopEntities();
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }

        public ActionResult Productcat(int? id)
        {
            var catid = id ?? 1;
            var category = db.categories.Find(catid);
            if (category == null)
                return View("Error");
            var model = category.products.ToList();
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return base.View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return base.View();
        }
    }
}