﻿using ShopNuocHoaTMD.Models;
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
        public ActionResult IndexBrand(int? id)
        {
            var items = _dbConnect.Product.ToList();
            if (id != null)
            {
                items = items.Where(x => x.Brand_Id == id).ToList();
            }
            return View(items);
        }
        public ActionResult IndexSearch(string Searchtext)
        {
            var items = _dbConnect.Product.ToList();
            if (Searchtext != null)
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Name.Contains(Searchtext)).ToList();
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
        public ActionResult ProductBrand(string alias, int? id)
        {
            var items = _dbConnect.Product.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.Brand_Id == id).ToList();
            }
            var brand = _dbConnect.Brand.Find(id);
            if (brand != null)
            {
                ViewBag.BrandTitle = brand.Name;
            }
            ViewBag.BrandId = id;
            return View(items);
        }
        public ActionResult Partial_ItemsByTopicID()
        {
            var items = _dbConnect.Product.Where(x => x.isHome).Take(15).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductBestSeller()
        {
            var items = _dbConnect.Product.Where(x => x.isHot).Take(10).ToList();
            return PartialView(items);
        }
        public ActionResult Detail(string alias, int? id)
        {
            var item = _dbConnect.Product.Find(id);
            return View(item);
        }

    }
}