using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeAPI.Models
{
    public class SanPhamBanChay
    {
        public int STT { get; set; }
        public string TenSP { get; set; }
        public int KhoiLuong { get; set; }
        public int SoLuongBan { get; set; }
        public int SoLuongHoaDon { get; set; }
    }
}