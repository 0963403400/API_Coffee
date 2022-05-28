namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETNHAPHANG")]
    public partial class CHITIETNHAPHANG
    {
        public int ID { get; set; }

        public int? SANPHAM_ID { get; set; }

        public int? NHAPHANG_ID { get; set; }

        public int? SOLUONGNHAP { get; set; }

        public int? GIANHAP { get; set; }

        public int? SOLUONGCONLAI { get; set; }

        //public virtual NHAPHANG NHAPHANG { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }
    }
}
