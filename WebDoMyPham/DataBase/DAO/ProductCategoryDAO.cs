using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public static class ProductCategoryDAO
    {
        private static MyPhamContext db = new MyPhamContext();

        public static ProductCategory GetByID(int categoryID)
        {
            return db.ProductCategories.Find(categoryID);
        }
        public static List<ProductCategory> GetList()
        {
            return (from p in db.ProductCategories where p.ParentID != null select p).ToList();
        }
        public static List<ProductCategory> GetListParent()
        {
            return (from p in db.ProductCategories where p.ParentID == null select p).ToList();
        }
        public static List<Product> GetListProduct(int categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            return db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}