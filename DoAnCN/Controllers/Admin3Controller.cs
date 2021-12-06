using DoAnCN.Models;
using DoAnCN.Models.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DoAnCN.Controllers
{
    public class Admin3Controller : Controller
    {
        // GET: Admin3
        public ActionResult Index()
        {
            return View();
        }
        DulichEntities7 db = new DulichEntities7();
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var taikhoan = collection["txtusername"];
            var matkhau = collection["txtpassword"];
            if (String.IsNullOrEmpty(taikhoan))
            {
                ViewData["loi1"] = "Tên tài khoản không được để trống";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["loi2"] = "Mật Khẩu không được để trống";
            }
            else
            {
                AdminT kh = db.AdminTs.SingleOrDefault(n => n.EmailAD == taikhoan && n.PasswordAD == matkhau);
                if (kh != null)
                {
                    Session["TaiKhoanadmin"] = kh;
                    return RedirectToAction("ListTourAd", "Admin3");
                }
                else
                    ViewBag.Thongbao = "Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng";
            }
            return View();

        }

        public ActionResult HomeAdmin()
        {
            int page = 1; int pagesize = 100;

            var db = TourBUS.DanhSach().ToPagedList(page, pagesize);
            return View(db);
        }

        public ActionResult ListTourAd()
        {
            var listTour = db.Tours.ToList();
            return View(listTour);

        }

        public ActionResult CreateTour()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateTour(Tour tourAd)
        {
            Tour tour = db.Tours.SingleOrDefault(p => p.IdTour == tourAd.IdTour);
            if (tour == null)
            {
                db.Tours.Add(tourAd);
                db.SaveChanges();

            }
           
            return RedirectToAction("ListTourAd");
        }


        public ActionResult DeleteTour(int id)
        {

            Tour tour = db.Tours.SingleOrDefault(p => p.IdTour == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
        [HttpPost, ActionName("DeleteTour")]

        public ActionResult DeleteTour1(int id)
        {

            Tour tour = db.Tours.SingleOrDefault(p => p.IdTour == id);
            if(tour != null)
            {
                db.Tours.Remove(tour);
                db.SaveChanges();
            }    

            

            return RedirectToAction("ListTourAd");

        }

        public ActionResult EditTourTe(int id)
        {
            Tour tour = db.Tours.SingleOrDefault(p => p.IdTour == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTourTe(Tour tourAd, HttpPostedFileBase file1)
        {
            Tour tour = db.Tours.SingleOrDefault(p => p.IdTour == tourAd.IdTour);
            if (tour != null)
            {
                
                UpdateModel(tourAd);
                db.Tours.AddOrUpdate(tourAd);
                db.SaveChanges();

            }
            return RedirectToAction("ListTourAd");
        }



        public ActionResult ListCustumerAd()
        {
            var listCustumer = db.Custumers.ToList();
            return View(listCustumer);

        }


        public ActionResult EditCustumer(int id)
        {
            Custumer custumer = db.Custumers.SingleOrDefault(p => p.IdCustumer == id);
            if (custumer == null)
            {
                return HttpNotFound();
            }
            return View(custumer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustumer(Custumer cus)
        {
            Custumer custumer = db.Custumers.SingleOrDefault(p => p.IdCustumer == cus.IdCustumer);
            if (custumer != null)
            {

                UpdateModel(cus);
                db.Custumers.AddOrUpdate(cus);
                db.SaveChanges();

            }
            return RedirectToAction("ListCustumerAd");
        }


        public ActionResult DeleteCustumer(int id)
        {

            Custumer custumer = db.Custumers.SingleOrDefault(p => p.IdCustumer == id);
            if (custumer == null)
            {
                return HttpNotFound();
            }
            return View(custumer);
        }
        [HttpPost, ActionName("DeleteCustumer")]
        public ActionResult DeleteCustumer1(int id)
        {
            Custumer custumer = db.Custumers.SingleOrDefault(p => p.IdCustumer == id);
            if (custumer != null)
            {
                db.Custumers.Remove(custumer);
                db.SaveChanges();
            }

            return RedirectToAction("ListCustumerAd");

        }



        public ActionResult ListInfoAd()
        {
            var ListInfo = db.InfoContacts.ToList();
            return View(ListInfo);

        }


        public ActionResult EditInfo(int id)
        {
            InfoContact infoContact = db.InfoContacts.SingleOrDefault(p => p.IdContact == id);
            if (infoContact == null)
            {
                return HttpNotFound();
            }
            return View(infoContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(InfoContact inf)
        {
            InfoContact infoContact = db.InfoContacts.SingleOrDefault(p => p.IdContact == inf.IdContact);
            if (infoContact != null)
            {

                UpdateModel(inf);
                db.InfoContacts.AddOrUpdate(inf);
                db.SaveChanges();

            }
            return RedirectToAction("ListInfoAd");
        }


        public ActionResult DeleteInfo(int id)
        {

            InfoContact infoContact = db.InfoContacts.SingleOrDefault(p => p.IdContact == id);
            if (infoContact == null)
            {
                return HttpNotFound();
            }
            return View(infoContact);
        }
        [HttpPost, ActionName("DeleteInfo")]
        public ActionResult DeleteInfo1(int id)
        {
            InfoContact infoContact = db.InfoContacts.SingleOrDefault(p => p.IdContact == id);
            if (infoContact != null)
            {
                db.InfoContacts.Remove(infoContact);
                db.SaveChanges();
            }

            return RedirectToAction("ListInfoAd");

        }

        public ActionResult ListDetailAd()
        {
            var listDetail = db.DetailTours.ToList();
            return View(listDetail);

        }

        public ActionResult EditDetail(int id)
        {
            DetailTour detailTour = db.DetailTours.SingleOrDefault(p => p.IdContact == id);
            if (detailTour == null)
            {
                return HttpNotFound();
            }
            return View(detailTour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetail(DetailTour inf)
        {
            DetailTour detailTour = db.DetailTours.SingleOrDefault(p => p.IdContact == inf.IdContact);
            if (detailTour != null)
            {

                UpdateModel(inf);
                db.DetailTours.AddOrUpdate(inf);
                db.SaveChanges();

            }
            return RedirectToAction("ListDetailAd");
        }

        [HttpPost]
        public ActionResult GuiMail1(DoAnCN.Models.Data.Gmail model)
        {

            MailMessage mm = new MailMessage("yukithang0@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = true;

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