namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRICE")]
    public partial class PRICE
    {
        public int ID { get; set; }

        public int? GIABAN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BATDAU { get; set; }

        [Column(TypeName = "date")]
        public DateTime? KETTHUC { get; set; }

        public int? SANPHAM_ID { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }
    }
}
