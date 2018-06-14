namespace WebDoMyPham.DataBase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int AccountID { get; set; }

        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(30)]
        public string Password { get; set; }
    }
}
