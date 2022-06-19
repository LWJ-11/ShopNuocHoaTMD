using ShopNuocHoaTMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index(int? id)
        {
            var items = _dbConnect.Product.ToList();
            if(id != null)
            {
                items = items.Where(x => x.Topic_Id == id).ToList();
            }
            return View(items);
        }
        public ActionResult ProductTopic(string alias, int? id)
        {
            var items = _dbConnect.Product.ToList();
            if (id >0)
            {
                items = items.Where(x => x.Topic_Id == id).ToList();
            }
            var topic = _dbConnect.Topic.Find(id);
            if (topic != null)
            {
                ViewBag.TopicTitle = topic.Title;
            }
            ViewBag.TopicId = id;
            return View(items);
        }
        public ActionResult Partial_ItemsByTopicID()
        {
            var items = _dbConnect.Product.Where(x => x.isHome).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductBestSeller()
        {
            var items = _dbConnect.Product.Where(x => x.isHot).Take(12).ToList();
            return PartialView(items);
        }

    }
}