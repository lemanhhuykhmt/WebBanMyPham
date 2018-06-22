using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoMyPham.DataBase.EF;
using WebDoMyPham.Models;

namespace WebDoMyPham.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {

            return View(Session["CartSession"] as List<CartItem>);
        }

        public ActionResult AddItem(int productID, int quantity = 1)
        {
            var cart = Session["CartSession"];
            Product product = DataBase.DAO.ProductDAO.GetByID(productID);
            if (cart == null)
            {
                List<CartItem> listItem = new List<CartItem>();
                listItem.Add(new CartItem() { Product = product, Quantity = quantity });
                Session["CartSession"] = listItem;
            }
            else
            {
                List<CartItem> listItem = cart as List<CartItem>;
                if(listItem.Exists(x=>x.Product.ProductID == productID)) // nếu sản phẩm đã có trong giỏ
                {
                    foreach(var item in listItem)
                    {
                        if(item.Product.ProductID == product.ProductID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else // chưa có trong giỏ
                {
                    listItem.Add(new CartItem() { Product = product, Quantity = quantity });
                }
                Session["CartSession"] = listItem;
            }
            return RedirectToAction("Index");
        }
    }
}