using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public class DetailBillDAO
    {
        private static MyPhamContext db = new MyPhamContext();

        public static bool Insert(DetailBill detail)
        {
            try
            {
                db.DetailBills.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}