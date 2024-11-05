using _63CNTT4N1.Library;
using MyClass.DAO;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _63CNTT4N1.Controllers
{
    public class KhachhangController : Controller
    {
        UsersDAO usersDAO = new UsersDAO();

        // GET: Khachhang DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(Users users)
        {
            Users row_user = usersDAO.getRow(users.Username, "customer");
            if (row_user == null)
            {
                TempData["message"] = new XMessage("danger", "Đăng nhập thất bại (Tên đăng nhập không tồn tại)");
                return RedirectToAction("DangNhap");
            }
            else
            {
                if (row_user.Password != users.Password)
                {
                    TempData["message"] = new XMessage("danger", "Đăng nhập thất bại (Mật khẩu không đúng)");
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    Session["UserCustomer"] = row_user.Username;
                    return RedirectToAction("Home", "Site");
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////
        // GET: Khachhang DangKy
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(Users users)
        {
            if (ModelState.IsValid)
            {
                var listuser = usersDAO.getList().Select(m => m.Username);
                users.Role = "customer";
                if (listuser.Contains(users.Username) && users.Role == "customer")
                {
                    TempData["message"] = new XMessage("danger", "Đăng ký thất bại (tên đăng nhập đã tồn tại)");
                    return RedirectToAction("DangKy");
                }
                //CreateAt
                users.CreateAt = DateTime.Now;
                //CreateBy
                users.CreateBy = Convert.ToInt32(Session["UserID"]);
                //CreateAts
                users.UpdateAt = DateTime.Now;
                //CreateBy
                users.UpdateBy = Convert.ToInt32(Session["UserID"]);
                users.Status = 1;
                usersDAO.Insert(users);
                TempData["message"] = new XMessage("success", "Đăng ký thành công");
                return RedirectToAction("DangKy");
            }
            return View(users);
        }

        public ActionResult DangXuat()
        {
            Session.Remove("UserCustomer");
            FormsAuthentication.SignOut();
            XCart xcart = new XCart();
            xcart.DelCart();
            Session["Qual"] = "0";
            return RedirectToAction("Home", "Site");
        }
    }
}