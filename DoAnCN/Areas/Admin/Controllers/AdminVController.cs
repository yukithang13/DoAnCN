using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnCN.Models;


namespace DoAnCN.Areas.Admin.Controllers
{
    public class AdminVController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Homea()
        {
            return View();
        }
        DulichEntities6 db = new DulichEntities6();
        [HttpPost]
        public ActionResult LoginV(AdminT user)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Message = "";
                var ab_dangnhap = db.AdminTs.Where(s => s.EmailAD.Equals(user.EmailAD) && s.PasswordAD.Equals(user.PasswordAD)).ToList();

                if (ab_dangnhap.Count() > 0)
                {
                    Session["TaiKhoan"] = ab_dangnhap.FirstOrDefault().EmailAD;
                    Session["MatKhau"] = ab_dangnhap.FirstOrDefault().PasswordAD;
                    Session["ThanhCong"] = user;
                    return RedirectToAction("Login", "AdminV");
                }
                else
                {
                    ViewBag.Message = "Sai";
                }
            }
            else
            {
                ViewBag.Message = "Nhập lại";
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }
    }
}