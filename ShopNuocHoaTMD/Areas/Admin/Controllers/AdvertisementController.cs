using PagedList;
using ShopNuocHoaTMD.DesignPattern;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class AdvertisementController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/Advertisement
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Advertisement> items = _dbConnect.Advertisements.OrderByDescending(x => x.Adv_Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Advertisement model)
        {
            if (ModelState.IsValid)
            {
                SingletonPattern singleton = SingletonPattern.GetInstance();
                singleton.AddAdvertisement(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _dbConnect.Advertisements.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisement model)
        {
            if (ModelState.IsValid)
            {
                SingletonPattern singleton = SingletonPattern.GetInstance();
                singleton.EditAdvertisement(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            SingletonPattern singleton = SingletonPattern.GetInstance();
            if (singleton.RemoveAdvertisement(id))
                return Json(new { success = true });
            return Json(new { success = false });
        }
    }
}