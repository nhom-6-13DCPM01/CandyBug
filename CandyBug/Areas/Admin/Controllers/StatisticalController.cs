using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Areas.Admin.Models.DAO;

namespace CandyBug.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            Statistical_DAO statistical_DAO = new Statistical_DAO();
            return View(statistical_DAO.getDanhSachThongKe());
        }
    }
}