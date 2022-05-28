namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        public int ID { get; set; }

        public string NOIDUNG { get; set; }

        public int? SOSAO { get; set; }

        public int? SANPHAM_ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        //public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }
    }
}
