using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.DataBase.DAO;

namespace WebDoMyPham.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var modelParent = ProductCategoryDAO.GetListParent();
            var model = ProductCategoryDAO.GetList();
            ViewBag.CategoryParent = modelParent;
            ViewBag.Category = model;
            return PartialView();
        }


        public ActionResult DetailProduct(int id)
        {
            var product = ProductDAO.GetByID(id);
            ViewBag.ListRelateProduct = ProductDAO.GetListRelateProduct(id, 4);
            return View(product);
        }

        public ActionResult DetailCategory(int id)
        {
            var listProduct = ProductCategoryDAO.GetListProduct(id);
            ViewBag.Category = ProductCategoryDAO.GetByID(id);
            return View(listProduct);
        }
    }
}