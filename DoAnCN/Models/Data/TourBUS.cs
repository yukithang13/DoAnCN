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
            var db = new DulichEntities6();
            return db.Tours.SqlQuery("select * from Tour ");

        }

        public static Tour ChiTiet(String a)
        {
            var db = new DulichEntities6();
            return db.Tours.Find("select * from Tour where IdTour = @0", a);
        }

        public void Update(Tour tourAd)
        {
            var db = new DulichEntities6();
            db.Entry(tourAd).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static IEnumerable<Tour> Top4()
        {
            var db1 = new DulichEntities6();
            return db1.Tours.SqlQuery("select Top 4 * from Tour where LuotView > '100'   ");
        }

        //public static void InsertSP(Tour sp)
        //{
        //    var db = new TravelDbContext();
        //    db.Tours.Add(sp);
        //}
 

        ////----------------------------------update images---------------
        //public static void UpdateImages(string id, string images)
        //{
        //    var db = new TravelDbContext();
        //    var sp = ChiTiet(id);
        //    sp.ImageTour = images;
        //    db.Tours.Add(sp);
        //}
        ////------------------------Loai ảnh đại diện cho hình ảnh-------------
        //public static string LoadAvartaImg(string id)
        //{
        //    var sp = ChiTiet(id);

        //    var product = ChiTiet(id);
        //    var images = product.ImageTour;
        //    XElement xImages = XElement.Parse(images);
        //    List<string> listImageReturn = new List<string>();

        //    foreach (XElement element in xImages.Elements())
        //    {
        //        listImageReturn.Add(element.Value);
        //    }
        //    if (listImageReturn.Count() == 0)
        //    {
        //        return "/Asset/data/images/default.png";
        //    }
        //    return listImageReturn.ElementAt(0).ToString();
        //}

        public IEnumerable<Tour> Tours { get; set; }
        
        public IEnumerable<AdminT> Admin { get; set; }


        


    }
}