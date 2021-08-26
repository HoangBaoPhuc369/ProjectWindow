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

        public int IDCustomer { get; set; }

        public int IDEmployee { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Product Product { get; set; }
    }
}
