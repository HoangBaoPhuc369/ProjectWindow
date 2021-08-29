namespace ShopPet.DataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Product { get; set; }

        public int? Quanlity { get; set; }

        public double? Price { get; set; }

        public double? Total { get; set; }

        public int? IDBills { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
