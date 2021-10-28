namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            DetailTours = new HashSet<DetailTour>();
            Populars = new HashSet<Popular>();
        }

        [Key]
        public int IdTour { get; set; }

        [StringLength(100)]
        public string TitleTour { get; set; }

        public string DescTour { get; set; }

        [StringLength(150)]
        public string ImageTour { get; set; }

        [StringLength(100)]
        public string StartingGate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartTour { get; set; }

        public int? TimeTour { get; set; }

        [StringLength(100)]
        public string Hotel { get; set; }

        [StringLength(50)]
        public string Vehicle { get; set; }

        public int? LuotView { get; set; }

        public int? IdCustumer { get; set; }

        [Column(TypeName = "money")]
        public decimal? PriceTour { get; set; }

        public virtual Custumer Custumer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailTour> DetailTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Popular> Populars { get; set; }

       
    }
}
