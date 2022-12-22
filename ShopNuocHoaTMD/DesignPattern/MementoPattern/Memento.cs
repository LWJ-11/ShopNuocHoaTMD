using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.DesignPattern.MementoPattern
{
    public class Memento
    {
        public int Blog_Id;
        public string Title;
        public string Description;
        public string Content;
        public string CoverImage;
        public string Author;

        public Memento()
        {
        }

        public Memento(int blogId, string title, string description, string content, string coverImage, string author)
        {
            this.Blog_Id = blogId;
            this.Title = title;
            this.Description = description;
            this.Content = content;
            this.CoverImage = coverImage;
            this.Author = author;
        }
    }
}