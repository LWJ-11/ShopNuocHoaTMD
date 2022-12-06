using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    public class FavoriteProduct
    {
        public FavoriteProduct() { 
            this.Products = new HashSet<Product>();
            this.Users = new HashSet<ApplicationUser>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Fav_Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}