using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Security.Policy;

namespace ShopNuocHoaTMD.Areas.Admin.Controllers
{
    public class ProductStockController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/ProductStock
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = _dbConnect.ProductStock.Where(x => x.Product_Id == id).ToList();
            return View(items);
        }
        public ActionResult AddStock(int volume, int quantity, decimal price, int productId)
        {
            _dbConnect.ProductStock.Add(new ProductStock
            {
                Product_Id = productId,
                Volume = volume,
                Quantity = quantity,
                Price = price,

            });
            _dbConnect.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConnect.ProductStock.Find(id);
            _dbConnect.ProductStock.Remove(item);
            _dbConnect.SaveChanges();
            return Json(new { success = true });
        }
    }
}