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
    
    public partial class Popular
    {
        public int IdPopular { get; set; }
        public Nullable<int> IdTour { get; set; }
    
        public virtual Tour Tour { get; set; }
    }
}
