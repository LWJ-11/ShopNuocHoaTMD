using ShopNuocHoaTMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        public ActionResult Index()
        {
            var items = _dbConnect.Advertisements.ToList();
            return View(items);
        }
        public ActionResult Refresh()
        {
            var item = new StatisticModel();

            ViewBag.vistors_online = HttpContext.Application["visitor_online"];
            item.Today = HttpContext.Application["Today"].ToString();
            item.Yesterday = HttpContext.Application["Yesterday"].ToString();
            item.ThisWeek = HttpContext.Application["ThisWeek"].ToString();
            item.LastWeek = HttpContext.Application["LastWeek"].ToString();
            item.ThisMonth = HttpContext.Application["ThisMonth"].ToString();
            item.LastMonth = HttpContext.Application["LastMonth"].ToString();
            item.Total = HttpContext.Application["Total"].ToString();
            return PartialView(item);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}