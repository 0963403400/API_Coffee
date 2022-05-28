namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            //BAIBAO = new HashSet<BAIBAO>();
            //BINHLUAN = new HashSet<BINHLUAN>();
            //CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
            //CHITIETNHAPHANG = new HashSet<CHITIETNHAPHANG>();
            //PRICE = new HashSet<PRICE>();
            //THONGKE = new HashSet<THONGKE>();
        }

        public int ID { get; set; }

        public int? KHOILUONG { get; set; }

        [StringLength(200)]
        public string ANH { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA { get; set; }

        public int? SOLUONG { get; set; }

        public int? LOAISP_ID { get; set; }

        public string TRANGTHAI { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BAIBAO> BAIBAO { get; set; }

        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BINHLUAN> BINHLUAN { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CHITIETNHAPHANG> CHITIETNHAPHANG { get; set; }

        //public virtual LOAISP LOAISP { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PRICE> PRICE { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<THONGKE> THONGKE { get; set; }
    }
}
