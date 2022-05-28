namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIBAO")]
    public partial class BAIBAO
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TIEUDE { get; set; }

        public string NOIDUNG { get; set; }

        public int? SANPHAM_ID { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }
    }
}
