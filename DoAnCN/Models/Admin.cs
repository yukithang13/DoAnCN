namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int IdAdmin { get; set; }

        [StringLength(15)]
        public string PasswordAD { get; set; }

        [StringLength(10)]
        public string EmailAD { get; set; }
    }
}
