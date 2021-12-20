using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CandyBug.Areas.Admin.Models.EF
{
    public class Statistical
    {
        public int maHoaDon { get; set; }
        public DateTime ngayTao { get; set; }
        public Nullable<decimal> tongTien { get; set; }
        public String trangThai { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
    }
}