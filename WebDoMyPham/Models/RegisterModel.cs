using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDoMyPham.Models
{
    public class RegisterModel
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        [Display(Name = "Tên Đăn Nhập")]
        public string UserName { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { set; get; }
    }
}