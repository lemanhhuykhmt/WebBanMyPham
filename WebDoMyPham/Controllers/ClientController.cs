using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.Common;
using WebDoMyPham.DataBase.DAO;
using WebDoMyPham.DataBase.EF;
using WebDoMyPham.Models;

namespace WebDoMyPham.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                if(CustomerDAO.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var customer = new Customer();
                    customer.UserName = model.UserName;
                    customer.Password = model.Password;
                    customer.CustomerName = model.CustomerName;
                    customer.Email = model.Email;
                    customer.Address = model.Address;
                    var result = CustomerDAO.Insert(customer);
                    if(result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = null;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = DataBase.DAO.CustomerDAO.Login(model.UserName, model.Password);
                if (res == true) // đăng nhập thành công
                {
                    Customer acc = CustomerDAO.GetByUserName(model.UserName);
                    AccountLogin accSession = new AccountLogin();
                    accSession.AccountID = acc.CustomerID;
                    accSession.UserName = acc.UserName;
                    accSession.Name = acc.CustomerName;
                    Session.Add("AccountSession", accSession);

                    //Chuyển đến đường link lúc đầu
                    var currentLink = Session["Link"];
                    if (currentLink != null)
                    {
                        Response.Redirect(currentLink.ToString());
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }

            return View();
        }
    }
}