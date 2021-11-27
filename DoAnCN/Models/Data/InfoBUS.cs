using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCN.Models.Data
{
    public class InfoBUS
    {
        public Custumer cus { get; set; }
        public Tour tou { get; set; }

        public InfoContact tourif { get; set; }
    }
}