namespace ShopPet.DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public int CusId { get; set; }

        [Required]
        [StringLength(50)]
        public string CusName { get; set; }

        [Required]
        [StringLength(50)]
        public string CusPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string CusAddr { get; set; }

        [Column(TypeName = "date")]
        public DateTime CusDOB { get; set; }
    }
}
