using ShopNuocHoaTMD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.DesignPattern.ProxyPattern
{
    public class BlogProxyPattern : Blogs
    {
        Blog blog;
        Blogs baiViet;
        int id;
        public BlogProxyPattern()
        {
            baiViet = null;
        }

        public BlogProxyPattern(Blog blog)
        {
            this.blog = blog;
        }
        public BlogProxyPattern(int id)
        {
            this.id = id;
        }

        public override void AddBlogs()
        {
            if (baiViet == null)
            {
                baiViet = new ConcreteBlog(blog);
            }
            baiViet.AddBlogs();
        }

        public override void EditBlogs()
        {
            if (baiViet == null)
            {
                baiViet = new ConcreteBlog(blog);
            }
            baiViet.EditBlogs();
        }

    }
}