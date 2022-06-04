using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_ProductPrice")]
    public class ProductPrice
    {
        [Key]
        [Column(Order = 1)]
        public int Product_Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Size_Id { get; set; }
        [Required]
        public float Price { get; set; }

        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        [ForeignKey("Size_Id")]
        public Size Size { get; set; }
    }
}