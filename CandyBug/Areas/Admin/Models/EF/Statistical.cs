using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandyBug.Areas.Admin.Models.EF
{
    public class Statistical
    {
        public int maHoaDon { get; set; }
        public DateTime ngayTao { get; set; }
        public Nullable<decimal> tongTien { get; set; }
        public String trangThai { get; set; }
    }
}