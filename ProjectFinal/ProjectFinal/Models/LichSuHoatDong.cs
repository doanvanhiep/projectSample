using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFinal.Models
{
    public class LichSuHoatDong
    {
        public string Ten_Thiet_Bi { get; set; }
        public string Trang_Thai { get; set; }
        public string Thoi_Gian { get; set; }

        public LichSuHoatDong(string tenThietBi, string trangThai, string thoiGian)
        {
            Ten_Thiet_Bi = tenThietBi;
            Trang_Thai = trangThai;
            Thoi_Gian = thoiGian;
        }
    }
}