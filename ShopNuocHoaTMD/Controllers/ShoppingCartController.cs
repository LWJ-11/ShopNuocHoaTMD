using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        public ActionResult CheckOutSucess()
        {
            return View();
        }
        public ActionResult Partial_Item_CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                return Json(new { count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { count = 0 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddtoCart(int id, int quantity, decimal price)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0};
            var db_Connect = new ApplicationDbContext();
            var checkProduct = db_Connect.Product.FirstOrDefault(x => x.Product_Id == id);
            if(checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if(cart == null)
                {
                    cart = new ShoppingCart(); 
                }
                ShoppingCartItem items = new ShoppingCartItem
                {
                    ProductId = checkProduct.Product_Id,
                    ProductName = checkProduct.Name,
                    ProductAlias = checkProduct.Alias,
                    CategoryName = checkProduct.Category.Name,
                    TopicName = checkProduct.Topic.Title,
                    Quantity = quantity,
                };
                if (checkProduct.ProductImage.FirstOrDefault(x => x.isDefault) != null)
                {
                    items.ProductImg = checkProduct.ProductImage.FirstOrDefault(x => x.isDefault).Image;
                }
                items.Price = price;
                items.TotalPrice = items.Quantity * items.Price;
                cart.AddToCart(items, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Item added to bag", code = 1, count = cart.Items.Count };
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuanity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if(checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = -1, count = cart.Items.Count };
                }
            }
            return Json(code);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var code = new { Success = false, code = -1 };
            if(ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                    Order order = new Order();
                    order.CustomerName = req.CustomerName;
                    order.Phone = req.Phone;
                    order.Address = req.Address;
                    cart.Items.ForEach(x => order.OrderDetail.Add(new OrderDetail
                    {
                        Product_Id = x.ProductId,
                        Quanity = x.Quantity,
                        Price = x.Price,
                        Order_Id = order.Order_Id
                    })); ;
                    order.TotalAmount = cart.Items.Sum(x => (x.Price * x.Quantity));
                    if (order.TotalAmount < 50)
                        order.TotalAmount += 17.99m;
                    order.Email = req.Email;
                    order.PaymentMethod = req.PaymentMethod;
                    order.OrderDate = DateTime.Now;
                    order.CreatedBy = req.Phone;
                    order.ModifiedBy = req.Phone;
                    order.CreatedDate = DateTime.Now;
                    order.ModifiedDate = DateTime.Now;
                    _dbConnect.Order.Add(order);
                    _dbConnect.SaveChanges();
                    cart.ClearCart();
                    code = new { Success = true, code = -1 };
                    return RedirectToAction("CheckOutSucess");
                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.ClearCart();
                return Json(new {Success = true});
            }
            return Json(new {Success = false});
        }
    }
}