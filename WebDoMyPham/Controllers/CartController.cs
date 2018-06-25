using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebDoMyPham.DataBase.DAO;
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
            return View(Session[CartSession] != null? Session[CartSession] as List<CartItem> : new List<CartItem>());
        }

        public ActionResult AddItem(int productID, int quantity = 1)
        {
            var cart = Session[CartSession];
            Product product = DataBase.DAO.ProductDAO.GetByID(productID);
            if (cart == null)
            {
                List<CartItem> listItem = new List<CartItem>();
                listItem.Add(new CartItem() { Product = product, Quantity = quantity });
                Session[CartSession] = listItem;
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
                Session[CartSession] = listItem;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = Session[CartSession] as List<CartItem>;

            for(int i = 0; i< sessionCart.Count; ++i)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductID == sessionCart[i].Product.ProductID);
                if(jsonItem != null)
                {
                    sessionCart[i].Quantity = jsonItem.Quantity;
                    if(sessionCart[i].Quantity <= 0)
                    {
                        sessionCart.Remove(sessionCart[i]);
                    }
                }
            }
            return Json(new {
                status = true               
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = Session[CartSession] as List<CartItem>;
            sessionCart.RemoveAll(x=>x.Product.ProductID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View(Session[CartSession] != null ? Session[CartSession] as List<CartItem> : new List<CartItem>());
        }

        [HttpPost]
        public ActionResult Payment(string receiver, string address,string phone)
        {

            var bill = new Bill();
            bill.CreatedDate = DateTime.Now;
            bill.Receiver = receiver;
            bill.Address = address;
            bill.Phone = phone;

            try
            {
                int id = BillDAO.Insert(bill);
                var sessionCart = Session[CartSession] != null ? Session[CartSession] as List<CartItem> : new List<CartItem>();
                foreach (var item in sessionCart)
                {
                    var detail = new DetailBill();
                    detail.BillID = id;
                    detail.UnitPrice = item.Product.PromotionPrice != null ? item.Product.PromotionPrice.Value : item.Product.Price.Value;
                    detail.Quantity = item.Quantity;
                    detail.ProductID = item.Product.ProductID;
                    DetailBillDAO.Insert(detail);
                }
            }
            catch (Exception ex)
            {
                //
            }


            return View("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}