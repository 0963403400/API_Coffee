namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGKE")]
    public partial class THONGKE
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAY { get; set; }

        public int SANPHAM_ID { get; set; }

        public int SOLUONGBAN { get; set; }

        public int DOANHTHU { get; set; }

        public int LOINHUAN { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }
    }
}
    