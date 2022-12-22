using PagedList;
using ShopNuocHoaTMD.DesignPattern.MementoPattern;
using ShopNuocHoaTMD.DesignPattern.ProxyPattern;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ShopNuocHoaTMD.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        CareTaker careTaker = new CareTaker();
        // GET: Admin/Blog
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Blog> items = _dbConnect.Blog.OrderByDescending(x => x.Blog_Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Title.Contains(Searchtext));
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
        public ActionResult Add(Blog model)
        {
            if (ModelState.IsValid)
            {
                Blogs blog = new BlogProxyPattern(model);
                blog.AddBlogs();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _dbConnect.Blog.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,Blog model, string submitButton)
        {
            if (ModelState.IsValid)
            {
                Blogs blog = new BlogProxyPattern(model);
                if (submitButton.ToString() == "Save")
                {
                    blog.EditBlogs();
                }
                else if (submitButton.ToString() == "Redo")
                {
                    var memetoSession = Session["Memento"];
                    careTaker.StoredBlog = (Memento)memetoSession;
                    model.RestoreProduct(careTaker.StoredBlog);
                    blog.EditBlogs();
                }
                else if (submitButton.ToString() == "SaveStage")
                {
                    Blog blog1 = new Blog();
                    blog1 = model;
                    blog1 = model.ShallowCoppy();
                    blog1 = model.DeepCopy();
                    Blog blogOlder = _dbConnect.Blog.Find(blog1.Blog_Id);
                    careTaker.StoredBlog = blogOlder.CreateStored(model);
                    careTaker.SaveMementoToSession(careTaker.StoredBlog);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConnect.Blog.Find(id);
            if (item != null)
            {
                _dbConnect.Blog.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}