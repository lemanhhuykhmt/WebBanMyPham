using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDoMyPham.DataBase.EF;

namespace WebDoMyPham.DataBase.DAO
{
    public static class AccountDAO
    {
        private static MyPhamContext db = new MyPhamContext();
        public static bool Login(string username, string password)
        {
            var res = db.Accounts.Count(x=>x.Username == username && x.Password == password);
            if(res > 0)
            {
                return true;
            }
            return false;
        }
        public static Account GetByUserName(string username)
        {
            return db.Accounts.SingleOrDefault(x => x.Username == username);
        }
    }
}