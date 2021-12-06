using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;
namespace CandyBug.Controllers
{
    public class HomeController : Controller
    {
        CandybugOnlineEntities db = new CandybugOnlineEntities();
        public ActionResult Index()
        {
            
            //Set Route đến vùng Admin
            /*return View("~/Areas/Admin/Views/Home/Index.cshtml");*/
            return View();
        }

        public ActionResult ListProduct()
        {
            var list = db.Products.ToList();
            return View(list);
        }
    }
}