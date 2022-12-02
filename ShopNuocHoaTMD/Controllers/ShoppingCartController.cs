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
        public ActionResult AddtoCart(int id, int quantity, decimal price, int stock)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0};
            var checkProduct = _dbConnect.Product.FirstOrDefault(x => x.Product_Id == id);
            if(checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if(cart == null)
                {
                    cart = new ShoppingCart(); 
                }
                var productStock = _dbConnect.ProductStock.FirstOrDefault(x => x.Volume == stock && checkProduct.Product_Id == x.Product_Id);
                if (productStock.Quantity < quantity)
                {
                    code = new { Success = false, msg = "This product is out of stock at this moment", code = 1, count = cart.Items.Count };
                }
                else
                {
                    ShoppingCartItem items = new ShoppingCartItem
                    {
                        ProductId = checkProduct.Product_Id,
                        ProductName = checkProduct.Name,
                        ProductAlias = checkProduct.Alias,
                        CategoryName = checkProduct.Category.Name,
                        TopicName = checkProduct.Topic.Title,
                        Quantity = quantity,
                    };
                    _dbConnect.ProductStock.Attach(productStock);
                    productStock.Quantity = productStock.Quantity - quantity;
                    if (checkProduct.ProductImage.FirstOrDefault(x => x.isDefault) != null)
                    {
                        items.ProductImg = checkProduct.ProductImage.FirstOrDefault(x => x.isDefault).Image;
                    }
                    items.Stock = stock;
                    items.Price = price;
                    items.TotalPrice = items.Quantity * items.Price;
                    cart.AddToCart(items, quantity);
                    Session["Cart"] = cart;
                    code = new { Success = true, msg = "Item added to bag", code = 1, count = cart.Items.Count };
                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity, int stock)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            int currentQuantity = cart.GetCurrentQuantity(id);
            if (cart != null)
            {
                var checkProduct = _dbConnect.Product.FirstOrDefault(x => x.Product_Id == id);
                var productStock = _dbConnect.ProductStock.FirstOrDefault(x => x.Volume == stock && checkProduct.Product_Id == x.Product_Id);
                if (productStock.Quantity < quantity)
                {
                    return Json(new { Success = false, msg = "This product is out of stock at this moment" });
                }
                else
                {
                    cart.UpdateQuanity(id, quantity);
                    if (quantity < currentQuantity)
                    {
                        productStock.Quantity = productStock.Quantity + (currentQuantity - quantity);
                        currentQuantity = quantity;
                    }
                    else
                    {
                        productStock.Quantity = productStock.Quantity - (quantity - currentQuantity);
                        currentQuantity = quantity;
                    }
                    return Json(new { Success = true });
                }
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
                if (checkProduct != null)
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
                    }));
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
                    for(int i = 0; i < cart.Items.Count; i++)
                    {
                        var item = cart.Items[i];
                        var checkProduct = _dbConnect.Product.FirstOrDefault(x => x.Product_Id == item.ProductId);
                        var productStock = _dbConnect.ProductStock.FirstOrDefault(x => x.Volume == item.Stock && checkProduct.Product_Id == x.Product_Id);
                        productStock.Quantity = productStock.Quantity - item.Quantity;
                    }
                    _dbConnect.Order.Add(order);
                    _dbConnect.SaveChanges();

                    //send mail cho customer sau khi đặt hàng
                    //Có thể hủy đơn hàng trước kkhi ad min duyệt đơn hàng
                    //cần gửi yêu cầu xác nhận chờ duyệt sau đó mới gửi chấp nhận đơn hàng
                    var strProduct = "";
                    var total = decimal.Zero;
                    var totalAmount = decimal.Zero;
                    foreach(var pd in cart.Items)
                    {
                        strProduct += "<tr>";
                        strProduct += "<td>" +pd.ProductName + pd.Stock+"ML"+"</td>";
                        strProduct += "<td>" + pd.Quantity + "</td>";
                        strProduct += "<td>" + "<span>$</span>" + pd.TotalPrice.ToString("0.00") + "</td>";
                        strProduct += "</tr>";
                        total += pd.Price * pd.Quantity;

                    }
                    if (total < 50)
                        totalAmount = total + 17.99m;
                    else
                        totalAmount = total;
                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{OrderID}}", order.Order_Id.ToString());
                    contentCustomer = contentCustomer.Replace("{{Product}}", strProduct);
                    contentCustomer = contentCustomer.Replace("{{CustomerName}}", order.CustomerName);
                    contentCustomer = contentCustomer.Replace("{{Phone}}", order.Phone);
                    contentCustomer = contentCustomer.Replace("{{Email}}", order.Email);
                    contentCustomer = contentCustomer.Replace("{{Address}}", order.Address);
                    contentCustomer = contentCustomer.Replace("{{PlaceOrderDate}}", order.ModifiedDate.ToString());
                    contentCustomer = contentCustomer.Replace("{{Total}}", total.ToString("0.00"));
                    contentCustomer = contentCustomer.Replace("{{TotalAmount}}", totalAmount.ToString("0.00"));
                    ShopNuocHoaTMD.Common.Common.SendMail("ShopNuocHoaTMD", "Order #" + order.Order_Id.ToString(), contentCustomer.ToString(), req.Email);
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