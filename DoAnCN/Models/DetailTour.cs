//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnCN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailTour
    {
        public int IdContact { get; set; }
        public int IdTour { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string Status { get; set; }
        public string Payments { get; set; }
        public Nullable<System.DateTime> PaymentTerm { get; set; }
    
        public virtual InfoContact InfoContact { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
