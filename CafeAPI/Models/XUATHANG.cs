namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XUATHANG")]
    public partial class XUATHANG
    {
        public int ID { get; set; }

        public int? CHITIETDH_ID { get; set; }

        public int? NHAPHANG_ID { get; set; }

        public int? SOLUONGXUAT { get; set; }

        public int? GIANHAP { get; set; }

        public int? GIABAN { get; set; }

        //public virtual CHITIETDONHANG CHITIETDONHANG { get; set; }

        //public virtual NHAPHANG NHAPHANG { get; set; }
    }
}
