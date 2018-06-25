using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public class BillDAO
    {
        private static MyPhamContext db = new MyPhamContext();
        public static int Insert(Bill bill)  
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill.BillID;
        }

    }
}