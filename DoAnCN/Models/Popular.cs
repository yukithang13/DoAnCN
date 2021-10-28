namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Popular")]
    public partial class Popular
    {
        [Key]
        public int IdPopular { get; set; }

        public int? IdTour { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
