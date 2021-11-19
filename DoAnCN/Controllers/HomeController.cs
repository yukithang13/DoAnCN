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

        DulichEntities6 db = new DulichEntities6();
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

        public ActionResult Info()
        {
            var employeeViewModel = new TourBUS
            {
                Tours = db.Tours.ToList(),
                
                Admin = db.AdminTs.ToList()
            };
            return View(employeeViewModel);
        }

        [HttpGet]
        public ActionResult Booking(int id)
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



        [HttpPost]
        public ActionResult Booking(List<Custumer> custumer)
        {
  
            foreach (Custumer Emp in custumer)
            {
                Custumer cus = db.Custumers.Find(Emp.IdCustumer);
                cus.FullNameCustumer = Emp.FullNameCustumer;
                cus.DateOfBirth = Emp.DateOfBirth;
                cus.Sex = Emp.Sex;
                cus.IdTour = Emp.IdTour;
            }
            db.SaveChanges();
            return View();
        }
        
    }
}