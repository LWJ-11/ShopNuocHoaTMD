using PagedList;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ShopNuocHoaTMD.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Blog
        public ActionResult Index(int? page)
        {

            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Blog> items = _dbConnect.Blog.OrderByDescending(x => x.Blog_Id);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items); ;
        }
        public ActionResult Detail(int id)
        {
            var item = _dbConnect.Blog.Find(id);
            return View(item);
        }
        public ActionResult PartialBlog()
        {
            var items = _dbConnect.Blog.OrderByDescending(x => x.ModifiedDate).ToList().Take(3);
            return PartialView("_PartialBlog", items);
        }
    }
}