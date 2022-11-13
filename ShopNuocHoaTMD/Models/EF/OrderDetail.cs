using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int Order_Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Product_Id { get; set; }
        public int Quanity { get; set; }
        public double TotalAmount { get; set; }

        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
    }
}