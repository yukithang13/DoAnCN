namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailTour")]
    public partial class DetailTour
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdContact { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTour { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(150)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Payments { get; set; }

        public DateTime? PaymentTerm { get; set; }

        public virtual InfoContact InfoContact { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
