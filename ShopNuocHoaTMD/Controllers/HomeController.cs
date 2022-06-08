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
            ViewData["Menu"] = _dbConnect.Menu;
            ViewData["Advertisement"] = _dbConnect.Advertisements;
            ViewData["Brand"] = _dbConnect.Brand;
            ViewData["Topic"] = _dbConnect.Topic;
            return View();
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