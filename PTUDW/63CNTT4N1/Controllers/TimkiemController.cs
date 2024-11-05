using _63CNTT4N1.Library;
using System.Web.Mvc.Ajax;
using MyClass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _63CNTT4N1.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem
        public ActionResult Index()
        {
            ProductsDAO productsDAO = new ProductsDAO();
            return View(productsDAO.getList("Index").Where(m => m.Status == 1));
        }

        [HttpPost]
        public ActionResult Index(string stringSearch)
        {
            if (String.IsNullOrEmpty(stringSearch))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProductsDAO productsDAO = new ProductsDAO();
                var list = productsDAO.getList("Index").Where(m => m.Status == 1 && m.Name.ToLower().Contains(stringSearch.ToLower()));
                if (!list.Any())
                {
                    TempData["message"] = new XMessage("danger", "Không tìm thấy sản phẩm");
                    return View(list);
                }
                else
                {
                    return View(list);
                }
            }
        }
    }
}