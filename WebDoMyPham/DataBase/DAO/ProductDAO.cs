using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public static class ProductDAO
    {
        private static MyPhamContext db = new MyPhamContext();
        public static List<Product> GetList()
        {
            return (from p in db.Products select p).ToList();
        }
        public static int Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ProductID;
        }
        public static bool Update(Product entity)
        {
            try
            {
                Product sp = db.Products.Find(entity.ProductID);
                sp.ProductName = entity.ProductName;
                sp.CategoryID = entity.CategoryID;
                sp.Image = entity.Image;
                sp.Price = entity.Price;
                sp.Measure = entity.Measure;
                sp.Description = entity.Description;
                sp.Content = entity.Content;
                sp.Quantity = entity.Quantity;
                sp.Status = entity.Status;
                sp.ShowHome = entity.ShowHome;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                var sp = db.Products.Find(id);
                db.Products.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Product GetByID(int? id)
        {
            return db.Products.Find(id);
        }
    }
}