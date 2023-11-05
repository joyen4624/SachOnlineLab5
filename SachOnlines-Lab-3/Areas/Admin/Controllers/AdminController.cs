using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SachOnlines_Lab_3.Models;

namespace SachOnlines_Lab_3.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private SachOnlineEntities db = new SachOnlineEntities();

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login([Bind(Include = "TenDN, MatKhau")] ADMIN user)
        {
            if (ModelState.IsValid)
            {

                var existingUser = db.ADMINs.SingleOrDefault(u => u.TenDN == user.TenDN && u.MatKhau == user.MatKhau);

                if (existingUser != null)
                {
                    // Lưu thông tin đăng nhập vào phiên
                    Session["isIDUser"] = existingUser.MaAd.ToString();
                    Session["isUserName"] = existingUser.HoTen;
                    Session["TaiKhoan"] = existingUser;

                    // Điều hướng đến trang chính sau khi đăng nhập
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.LoginFailed = true;
                    ViewBag.Notification = "Tên tài khoản hoặc mật khẩu không hợp lệ!";
                }
            }

            return View(user);
        }

        // GET: Admin/Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMINs.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // GET: Admin/Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaAd,HoTen,DienThoai,TenDN,MatKhau,Quyen")] ADMIN aDMIN)
        {
            if (ModelState.IsValid)
            {
                db.ADMINs.Add(aDMIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDMIN);
        }

        // GET: Admin/Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMINs.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // POST: Admin/Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaAd,HoTen,DienThoai,TenDN,MatKhau,Quyen")] ADMIN aDMIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMIN);
        }

        // GET: Admin/Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMINs.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMIN aDMIN = db.ADMINs.Find(id);
            db.ADMINs.Remove(aDMIN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
