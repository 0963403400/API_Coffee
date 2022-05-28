namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETDONHANG()
        {
            //XUATHANG = new HashSet<XUATHANG>();
        }
        public CHITIETDONHANG(int idSP, int idDH, int soluong, int dongia)
        {
            SANPHAM_ID = idSP;
            DONHANG_ID = idDH;
            SOLUONG = soluong;
            DONGIA = dongia;
        }

        public int ID { get; set; }

        public int? SANPHAM_ID { get; set; }

        public int? DONHANG_ID { get; set; }

        public int? SOLUONG { get; set; }

        public int? DONGIA { get; set; }

        //public virtual DONHANG DONHANG { get; set; }

        //public virtual SANPHAM SANPHAM { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<XUATHANG> XUATHANG { get; set; }
    }
}
