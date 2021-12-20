using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Areas.Admin.Model.DAO;
using CandyBug.Areas.Admin.Model.EF;
using CandyBug.Models;
using System.Web.Routing;

namespace CandyBug.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        private Statistical_DAO statistical = new Statistical_DAO();
        private CandybugOnlineEntities DBCandyBug = new CandybugOnlineEntities();

        // GET: Admin/Statistical
        public ActionResult Index()
        {
            return View(statistical.getDanhSachThongKe());
        }

        [HttpGet, ActionName("Detail")]
        //Hiển thị thông tin chi tiết về hóa đơn
        public ActionResult Detail(int id)
        {
            var hoaDon = DBCandyBug.Oders.Find(id);
            ViewBag.HoaDon = new Statistical
            {
                maHoaDon = hoaDon.Id,
                ngayTao = hoaDon.DateCreate,
                trangThai = hoaDon.Status
            };
            return View(statistical.getThongTinHoaDon(id));
        }

        public ActionResult LocTheoNgay()
        {
            return View();
        }

        [HttpPost, ActionName("LocTheoNgay")]
        public ActionResult LocTheoNgay(DateTime fromDate, DateTime toDate)
        {
            List<Statistical> danhSach;
            if ((fromDate.Date > toDate.Date))
            {
                ViewBag.ThongBaoLoiDuLieuDauVao = "Vui lòng chọn lại ngày!";
                return View();
            }
            else
            {
                danhSach = statistical.getDanhSachThongKeByDate(fromDate, toDate);
            }
            return View("ThongKeByDate", danhSach);
        }

        [ActionName("ThongKeByDate")]
        public ActionResult ThongKeByDate(List<Statistical> danhSach)
        {
            return View(danhSach);
        }
    }
}