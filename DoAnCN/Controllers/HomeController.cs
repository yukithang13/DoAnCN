using DoAnCN.Models;
using DoAnCN.Models.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult ContactHome()
        {

            return View();
        }

        public ActionResult Ct()
        {
            return View();
        }

        TravelContext db = new TravelContext();
        public ActionResult Tour()
        {
            int page = 1; int pagesize = 16;

            var db = TourBUS.DanhSach().ToPagedList(page, pagesize);
            var db1 = TourBUS.Top4().ToPagedList(1, 3);
            var mut = new { db, db1 };

            return View(db1);
            
        }



        //[HttpGet]
        //public ActionResult Tour(Tour tour)
        //{
        //    Tour tourdb = new Tour();
        //    tourdb.TitleTour = tour.TitleTour;
        //    tour.DescTour = tourdb.DescTour;
        //    tour.ImageTour = tourdb.ImageTour;
        //    tour.StartingGate = tourdb.StartingGate;
        //    tour.StartTour = tourdb.StartTour;
        //    tour.TimeTour = tourdb.TimeTour;
        //    tour.Hotel = tourdb.Hotel;
        //    tour.Vehicle = tourdb.Vehicle;
        //    tour.IdCustumer = tourdb.IdCustumer;
        //    tour.PriceTour = tourdb.PriceTour;

        //    return View();
        //}
    }
}