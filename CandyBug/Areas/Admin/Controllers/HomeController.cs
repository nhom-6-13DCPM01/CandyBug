using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;

namespace CandyBug.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}