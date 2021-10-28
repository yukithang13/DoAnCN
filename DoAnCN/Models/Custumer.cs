namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Custumer")]
    public partial class Custumer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Custumer()
        {
            Tours = new HashSet<Tour>();
        }

        [Key]
        public int IdCustumer { get; set; }

        [StringLength(100)]
        public string FullNameCustumer { get; set; }

        [StringLength(50)]
        public string DateOfBirth { get; set; }

        [StringLength(50)]
        public string Sex { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
