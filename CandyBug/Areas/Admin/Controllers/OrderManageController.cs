using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;
using CandyBug.Areas.Admin.Model.DAO;
using CandyBug.Areas.Admin.Model.EF;
using System.Net;

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
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<String> trangThai = new List<string>() { "DUYỆT", "CHƯA DUYỆT", "GIAO HÀNG THÀNH CÔNG"};
            ViewBag.DanhSachTrangThai = trangThai;
            return View(order.timDonHang(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonHang donHang)
        {
            if (donHang.ngayGiao.Equals(null))
            {
                ViewBag.ThongBaoNgay = "Vui lòng chọn ngày";
                return View();
            }
            else
            {
                order.suaThongTinDonHang(donHang);
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Oders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = DBCandyBug.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }

        // POST: Admin/Oders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oder oder = DBCandyBug.Oders.Find(id);
            DBCandyBug.Oders.Remove(oder);
            DBCandyBug.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}