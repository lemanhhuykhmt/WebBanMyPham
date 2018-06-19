using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.DataBase.DAO;

namespace WebDoMyPham.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListNewProduct = ProductDAO.GetListNewProduct(4);
            ViewBag.ListHotProduct = ProductDAO.GetListHotProduct(4);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            return PartialView();
        }

        public ActionResult Ato()
        {
            return View();
        }
    }
}