namespace ShopPet.DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int ProId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProName { get; set; }

        [Required]
        [StringLength(20)]
        public string ProCate { get; set; }

        public double ProPrice { get; set; }

        public int ProQty { get; set; }

        [StringLength(50)]
        public string ProDes { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProImg { get; set; }
    }
}
