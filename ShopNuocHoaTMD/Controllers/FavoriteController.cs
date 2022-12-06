using ShopNuocHoaTMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Controllers
{
    public class FavoriteController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();

        // GET: Favorite
        public ActionResult Index()
        {
            
            return View();
        }
    }
}