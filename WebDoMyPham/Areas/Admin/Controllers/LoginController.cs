using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.Common;
using WebDoMyPham.DataBase.DAO;
using WebDoMyPham.DataBase.EF;
using WebDoMyPham.Models;

namespace WebDoMyPham.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var res = DataBase.DAO.AccountDAO.Login(model.UserName, model.Password);
                if (res == true) // đăng nhập thành công
                {
                    Account acc = AccountDAO.GetByUserName(model.UserName);
                    AccountLogin accSession = new AccountLogin();
                    accSession.AccountID = acc.AccountID;
                    accSession.UserName = acc.Username;
                    Session.Add("AccountSession", accSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View("Index");
        }
    }
}