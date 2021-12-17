using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandyBug.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.ActiveCart = "active";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.ActiveCheckout= "active";
            return View();
        }
    }
}