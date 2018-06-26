using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public static class CustomerDAO
    {
        private static MyPhamContext db = new MyPhamContext();
        public static bool CheckUserName(string username)
        {
            return db.Customers.Count(x=>x.UserName == username) > 0;
        }

        public static int Insert(Customer model)
        {
            db.Customers.Add(model);
            db.SaveChanges();
            return model.CustomerID;
        }

        public static bool Login(string username, string password)
        {
            var res = db.Customers.Count(x => x.UserName == username && x.Password == password);
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public static Customer GetByUserName(string username)
        {
            return db.Customers.SingleOrDefault(x => x.UserName == username);
        }
    }
}