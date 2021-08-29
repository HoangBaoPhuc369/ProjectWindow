namespace ShopPet.DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            Details = new HashSet<Detail>();
        }

        public int BillId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Billdate { get; set; }

        [Required]
        [StringLength(50)]
        public string CusName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        public double Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail> Details { get; set; }
    }
}
