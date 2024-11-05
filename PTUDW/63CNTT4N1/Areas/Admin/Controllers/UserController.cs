using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _63CNTT4N1.Library;
using MyClass.DAO;
using MyClass.Model;

namespace _63CNTT4N1.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/Category/Index
        public ActionResult Index()
        {
            UsersDAO usersDAO = new UsersDAO();
            return View(usersDAO.getList("Index"));
        }
    }
}
