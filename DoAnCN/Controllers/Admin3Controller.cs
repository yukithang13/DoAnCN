using DoAnCN.Models;
using DoAnCN.Models.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
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
        DulichEntities6 db = new DulichEntities6();
        
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
                    return RedirectToAction("HomeAdmin", "Admin3");
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
    }
}