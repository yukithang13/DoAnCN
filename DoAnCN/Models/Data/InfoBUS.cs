using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCN.Models.Data
{
    public class InfoBUS
    {
        public static IEnumerable<Tour> DanhSach()
        {
            var db = new DulichEntities6();
            return db.Tours.SqlQuery("select * from Tour ");

        }
        public static void InsertInfo(Custumer sp)
        {
            var db = new DulichEntities6();
            db.Custumers.Add(sp);
            db.SaveChanges();
        }
    }
}