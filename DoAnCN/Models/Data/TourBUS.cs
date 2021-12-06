using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DoAnCN;


namespace DoAnCN.Models.Data
{
    public class TourBUS
    {
        public static IEnumerable<Tour> DanhSach()
        {
            var db = new DulichEntities7();
            return db.Tours.SqlQuery("select * from Tour ");

        }

        public static Tour ChiTiet(String a)
        {
            var db = new DulichEntities7();
            return db.Tours.Find("select * from Tour where IdTour = @0", a);
        }

        public void Update(Tour tourAd)
        {
            var db = new DulichEntities7();
            db.Entry(tourAd).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static IEnumerable<Tour> Top4()
        {
            var db1 = new DulichEntities7();
            return db1.Tours.SqlQuery("select Top 4 * from Tour where LuotView > '100'   ");
        }

        public static void InsertSP(Tour tour)
        {
            var db = new DulichEntities7();
            db.Tours.Add(tour);
            db.SaveChanges();
        }

        public IEnumerable<Tour> Tours { get; set; }
        
        public IEnumerable<AdminT> Admin { get; set; }


        


    }
}