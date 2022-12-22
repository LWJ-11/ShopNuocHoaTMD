using ShopNuocHoaTMD.DesignPattern.MementoPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_Blog")]
    public class Blog : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Blog_Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "This field is limited to 150 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [AllowHtml]
        [Required]
        public string Content { get; set; }
        [Required]
        public string CoverImage { get; set; }
        [Required]
        public string Author { get; set; }
        public Memento CreateStored(Blog blog)
        {
            return new Memento(blog.Blog_Id, blog.Title, blog.Description, blog.Content, blog.CoverImage, blog.Author);
        }
        public void RestoreProduct(Memento blogMemento)
        {
            this.Blog_Id = blogMemento.Blog_Id;
            this.Title = blogMemento.Title;
            this.Description = blogMemento.Description;
            this.Content = blogMemento.Content;
            this.CoverImage = blogMemento.CoverImage;
            this.Author = blogMemento.Author;
        }
    }
}