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
        public static List<ProductCategory> GetList()
        {
            return (from p in db.ProductCategories where p.ParentID != null select p).ToList();
        }
        public static List<ProductCategory> GetListParent()
        {
            return (from p in db.ProductCategories where p.ParentID == null select p).ToList();
        }
    }
}