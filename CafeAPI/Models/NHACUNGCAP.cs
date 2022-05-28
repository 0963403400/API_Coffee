namespace CafeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            //NHAPHANG = new HashSet<NHAPHANG>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<NHAPHANG> NHAPHANG { get; set; }
    }
}
