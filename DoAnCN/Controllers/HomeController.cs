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
            

            var db = TourBUS.Top4().ToPagedList(1, 4);
            return View(db);
            
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

        DulichEntities1 db = new DulichEntities1();
        public ActionResult Tour()
        {
            int page = 1; int pagesize = 100;

            var db = TourBUS.DanhSach().ToPagedList(page, pagesize);
            return View(db);
            
        }


        public ActionResult TourInfo(int id)
        {
            var db = TourBUS.DanhSach();

            Tour tour1 = new Tour();
            
            foreach (Tour tour in db)
            {
                if (tour.IdTour == id)
                {
                    tour1 = tour;
                    break;
                }
            }
            if (tour1 == null)
            {
                return HttpNotFound();
            }
            return View(tour1);

           
            

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