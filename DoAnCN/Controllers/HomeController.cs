using DoAnCN.Models;
using DoAnCN.Models.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public ActionResult InsertInfo(InfoContact _customer)
        {
            InfoContact vv = new InfoContact();
            vv.FullName = _customer.FullName;
            vv.Email = _customer.Email;
            vv.Phone = _customer.Phone;
            vv.Note = _customer.Note;
            db.InfoContacts.Add(vv);
            db.SaveChanges();

            return Json(_customer);
        }

        [HttpPost]
        public ActionResult InsertCustomer(Custumer cus)
        {
            Custumer vv = new Custumer();

            vv.FullNameCustumer = cus.FullNameCustumer;
            vv.DateOfBirth = cus.DateOfBirth;
            vv.Sex = cus.Sex;
            vv.IdTour = cus.IdTour;
            db.Custumers.Add(vv);
            db.SaveChanges();

            return Json(cus);
        }


        [HttpPost]
        public ActionResult _Booking(List<Custumer> custumer)
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




        public ActionResult Ct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ct(DoAnCN.Models.Data.Gmail model)
        {

            MailMessage mm = new MailMessage("yukithang0@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("yukithang0@gmail.com", "thang123t");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Successfully";
            return View();
        }
    }
}