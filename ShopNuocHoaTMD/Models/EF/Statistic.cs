using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.EF
{
    [Table("tb_Statistic")]
    public class Statistic
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Stat_Id { get; set; }
        public DateTime TimeStat { get; set; }
        public long NumberOfVisits { get; set; }

    }
}