namespace ShopPet.DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int EmpID { get; set; }

        [StringLength(50)]
        public string EmpName { get; set; }

        [StringLength(50)]
        public string EmpAddr { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EmpDOB { get; set; }

        [StringLength(50)]
        public string EmpPhone { get; set; }

        [StringLength(50)]
        public string EmpPass { get; set; }

        [StringLength(50)]
        public string EmpUser { get; set; }

        [StringLength(10)]
        public string Permission { get; set; }
    }
}
