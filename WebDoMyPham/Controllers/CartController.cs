using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebDoMyPham.DataBase.EF;
using WebDoMyPham.Models;

namespace WebDoMyPham.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            return PartialView(Session["CartSession"] as List<CartItem>);
        }
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

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = Session["CartSession"] as List<CartItem>;

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductID == item.Product.ProductID);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            return Json(new {
                status = true
                
            });
        }
    }
}