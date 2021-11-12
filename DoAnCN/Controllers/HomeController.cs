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
        public ActionResult Tour123()
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


        public ActionResult Booking()
        {
            return View();
        }

        //public JsonResult LoadImages(string id)
        //{
        //    var product = TourBUS.ChiTiet(id);
        //    var images = product.;
        //    XElement xImages = XElement.Parse(images);
        //    List<string> listImageReturn = new List<string>();

        //    foreach (XElement element in xImages.Elements())
        //    {
        //        listImageReturn.Add(element.Value);
        //    }
        //    return Json(new
        //    {
        //        data = listImageReturn
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}