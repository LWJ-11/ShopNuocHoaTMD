using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_Size")]
    public class Size
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Size_Id { get; set; }

        [Required(ErrorMessage = "Không được để giá trị thể tích")]
        public double SizeValue { get; set; }
    }
}