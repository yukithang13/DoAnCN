using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCN.Models.Data
{
    public class PopularBUS
    {
        public IEnumerable<Tour> Tours { get; set; }
        public IEnumerable<Popular> Populars { get; set; }

       
    }
}