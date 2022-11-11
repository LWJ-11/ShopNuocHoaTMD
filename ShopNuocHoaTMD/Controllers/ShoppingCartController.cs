using ShopNuocHoaTMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
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
        public ActionResult AddtoCart(int id, int quantity)
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
                items.Price = checkProduct.Price;
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