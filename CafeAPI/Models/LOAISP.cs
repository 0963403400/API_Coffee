namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAISP")]
    public partial class LOAISP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAISP()
        {
            //SANPHAM = new HashSet<SANPHAM>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [StringLength(200)]
        public string ANH { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTAO { get; set; }

        public int? HANGSX_ID { get; set; }

        [StringLength(20)]
        public string TRANGTHAI { get; set; }

        //public virtual HANGSX HANGSX { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
