using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace DoAnCN.Models.Data
{
    public class TourBUS
    {
        public static IEnumerable<Tour> DanhSach()
        {
            var db = new TravelContext();
            return db.Tours.SqlQuery("select * from Tour ");

        }

        public static IEnumerable<Tour> Top4()
        {
            var db1 = new TravelContext();
            return db1.Tours.SqlQuery("select Top 4 * from Tour where LuotView > '100'   ");
        }




    }
}