using PagedList;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {

            IEnumerable<Product> items = _dbConnect.Product.OrderByDescending(x => x.Product_Id);
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.Topic = new SelectList(_dbConnect.Topic.ToList(), "Topic_Id", "Title");
            ViewBag.Brand = new SelectList(_dbConnect.Brand.ToList(), "Brand_Id", "Name");
            ViewBag.Category = new SelectList(_dbConnect.Category.ToList(), "Category_Id", "Name");
            return View();
        }
    }
}