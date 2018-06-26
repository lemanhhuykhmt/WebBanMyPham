using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDoMyPham.Common
{
    [Serializable]
    public class AccountLogin
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}