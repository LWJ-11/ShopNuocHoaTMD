using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_Order")]
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Order_Id { get; set; }
        [Required]
        public bool IsDelivered { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public int Delivery_Id { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
    }
}