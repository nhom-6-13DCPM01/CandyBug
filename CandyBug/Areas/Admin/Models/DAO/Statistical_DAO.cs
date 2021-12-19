using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CandyBug.Models;
using CandyBug.Areas.Admin.Models.EF;

namespace CandyBug.Areas.Admin.Models.DAO
{
    public class Statistical_DAO
    {
        CandybugOnlineEntities DBCandyBug;
        
        public Statistical_DAO() { DBCandyBug = new CandybugOnlineEntities(); }

        public List<Statistical> getDanhSachThongKe()
        {
            var danhSach = (from u in DBCandyBug.Oders
                            select new Statistical
                            {
                                maHoaDon = u.Id,
                                ngayTao = u.DateCreate.Value,
                                tongTien = u.OrderInfoes.Select(c => c.Total).Sum(),
                                trangThai = u.Status
                            }).ToList();
            return danhSach;
        }
    }
}