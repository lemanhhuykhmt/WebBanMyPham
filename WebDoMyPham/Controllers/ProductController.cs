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

        public ActionResult DetailCategory(int id, int page = 1, int pageSize = 16)
        {

            ViewBag.Category = ProductCategoryDAO.GetByID(id);
            int totalRecord = 0;
            var listProduct = ProductCategoryDAO.GetListProduct(id, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 3;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize)) + 1;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(listProduct);
        }
    }
}