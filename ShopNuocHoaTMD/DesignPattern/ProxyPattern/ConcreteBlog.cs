using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopNuocHoaTMD.Models;
using ShopNuocHoaTMD.Models.EF;

namespace ShopNuocHoaTMD.DesignPattern.ProxyPattern
{
    public class ConcreteBlog : Blogs
    {
        Blog blog;
        int id;

        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        public ConcreteBlog(Blog blog)
        {
            this.blog = blog;
        }

        public ConcreteBlog(int id)
        {
            this.id = id;
        }
        public override void AddBlogs()
        {
            blog.CreatedDate = DateTime.Now;
            blog.ModifiedDate = DateTime.Now;
            _dbConnect.Blog.Add(blog);
            _dbConnect.SaveChanges();
        }

        public override void EditBlogs()
        {
            _dbConnect.Blog.Attach(blog);
            blog.ModifiedDate = DateTime.Now;
            _dbConnect.Entry(blog).Property(x => x.Title).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.Content).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.Description).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.Author).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.CoverImage).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.ModifiedBy).IsModified = true;
            _dbConnect.Entry(blog).Property(x => x.ModifiedDate).IsModified = true;
            _dbConnect.SaveChanges();
        }
    }
}