using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.DataBase.DAO;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var products = ProductDAO.GetList();
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            setViewBagProductCategory();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductDAO.Insert(product);
                return RedirectToAction("Index");
            }
            setViewBagProductCategory();
            return View();
        }

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = ProductDAO.GetByID(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            setViewBagProductCategory(product.CategoryID);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]

        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductDAO.Update(product);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if(ModelState.IsValid)
            {
                ProductDAO.Delete(id);
            }
            return RedirectToAction("Index");
        }


        private void setViewBagProductCategory(int? id = null)
        {
            List<ProductCategory> listCategory = ProductCategoryDAO.GetList();
            SelectList slCategory = new SelectList(listCategory, "CategoryID", "CategoryName", id);
            ViewBag.slCategory = slCategory;
        }
    }
}
