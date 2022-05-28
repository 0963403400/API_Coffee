namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            //BINHLUAN = new HashSet<BINHLUAN>();
            //DONHANG = new HashSet<DONHANG>();
        }
       /* [Required(ErrorMessage = "Please enter the user's first name.")]*/
        public int ID { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [StringLength(30)]
        public string TENDANGNHAP { get; set; }

        [StringLength(50)]
        public string MATKHAU { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        public int? QUYEN { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BINHLUAN> BINHLUAN { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DONHANG> DONHANG { get; set; }
    }
}
