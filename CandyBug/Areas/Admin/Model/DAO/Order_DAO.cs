using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CandyBug.Areas.Admin.Model.EF;
using CandyBug.Models;

namespace CandyBug.Areas.Admin.Model.DAO
{
    public class Order_DAO
    {
        private CandybugOnlineEntities DBCandyBug = new CandybugOnlineEntities();
        public List<DonHang> getDanhSachDonHang()
        {
            var danhSach = (from u in DBCandyBug.Oders
                            select new DonHang
                            {
                                maHoaDon = u.Id,
                                ngayTao = u.DateCreate.Value,
                                diaChi = u.Address,
                                ngayGiao = u.DeliveryDate,
                                trangThai = u.Status,
                                soDienThoai = u.SDT,
                                tenNhanVien = u.Account.DisplayName
                            }).ToList();
            return danhSach;
        }

        public List<HoaDon> getThongTinHoaDon(int idOrder)
        {
            var danhSach = (from u in DBCandyBug.OrderInfoes
                            where u.IdOrder == idOrder
                            select new HoaDon
                            {
                                maHoaDon = u.IdOrder,
                                tenSanPham = u.Product.Name,
                                gia = u.Product.Price,
                                soLuong = u.Quantity,
                                tongTien = u.Total
                            }).ToList();
            return danhSach;
        }

        public void xoaDonHang(int maHoaDon)
        {
            Oder order = DBCandyBug.Oders.Find(maHoaDon);
            DBCandyBug.Oders.Remove(order);
            DBCandyBug.SaveChanges();
        }

        public void suaThongTinDonHang(DonHang donHang)
        {
            var orderFind = DBCandyBug.Oders.Find(donHang.maHoaDon);
            orderFind.DeliveryDate = donHang.ngayGiao.Value;
            orderFind.Status = donHang.trangThai;
            DBCandyBug.SaveChanges();
        }

        public DonHang timDonHang(int ID)
        {
            var donHang = (from u in DBCandyBug.Oders
                            where u.Id == ID
                            select new DonHang
                            {
                                maHoaDon = u.Id,
                                ngayTao = u.DateCreate.Value,
                                trangThai = u.Status,
                                ngayGiao = u.DeliveryDate,
                                diaChi = u.Address,
                                soDienThoai = u.SDT,
                                tenNhanVien = u.Account.DisplayName,
                            }).First();
            return donHang;
        }
    }
}