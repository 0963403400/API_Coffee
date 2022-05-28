namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAPHANG")]
    public partial class NHAPHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAPHANG()
        {
            //CHITIETNHAPHANG = new HashSet<CHITIETNHAPHANG>();
            //XUATHANG = new HashSet<XUATHANG>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }

        public int? NHACC_ID { get; set; }
        public int TONGTIEN { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CHITIETNHAPHANG> CHITIETNHAPHANG { get; set; }

        //public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<XUATHANG> XUATHANG { get; set; }
    }
}
