using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;
using CandyBug.Areas.Admin.Model.DAO;
using CandyBug.Areas.Admin.Model.EF;

namespace CandyBug.Areas.Admin.Controllers
{
    public class OrderManageController : Controller
    {
        private Order_DAO order = new Order_DAO();
        private CandybugOnlineEntities DBCandyBug = new CandybugOnlineEntities();

        // GET: Admin/OrderManage
        public ActionResult Index()
        {
            return View(order.getDanhSachDonHang());
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if(id != null)
            {
                var hoaDon = DBCandyBug.Oders.Find(id);
                ViewBag.HoaDon = new DonHang
                {
                    maHoaDon = hoaDon.Id,
                    ngayTao = hoaDon.DateCreate.Value,
                    trangThai = hoaDon.Status,
                    diaChi = hoaDon.Address,
                    ngayGiao = hoaDon.DeliveryDate,
                    soDienThoai = hoaDon.SDT,
                    tenNhanVien = hoaDon.Account.DisplayName
                };
                return View(order.getThongTinHoaDon(id.Value));
            }
            else
            {
                return View("Index");
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Edit(DonHang donHang)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}