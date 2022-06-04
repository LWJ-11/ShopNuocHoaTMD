using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_DeliveryMethod")]
    public class DeliveryMethod
    {
        public DeliveryMethod()
        {
            this.Order = new HashSet<Order>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Delivery_Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 kí tự")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}