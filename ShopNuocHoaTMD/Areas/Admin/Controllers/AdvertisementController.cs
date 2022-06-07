using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Areas.Admin.Controllers
{
    public class AdvertisementController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/Advertisement
        public ActionResult Index()
        {
            var items = _dbConnect.Advertisements;
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
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = ShopNuocHoaTMD.Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Advertisements.Add(model);
                _dbConnect.SaveChanges();
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
                _dbConnect.Advertisements.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = ShopNuocHoaTMD.Models.Common.Filter.FilterChar(model.Title);
                _dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.Image).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConnect.Advertisements.Find(id);
            if (item != null)
            {
                _dbConnect.Advertisements.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

    }
}