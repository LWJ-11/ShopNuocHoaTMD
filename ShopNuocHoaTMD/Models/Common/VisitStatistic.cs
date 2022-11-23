using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models.Common
{
    public class VisitStatistic
    {
        public static string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public static StatisticViewModel Statistic()
        {
            using(var connect = new SqlConnection(strConnect))
            {
                var item = connect.QueryFirstOrDefault<StatisticViewModel>("sp_Statistic", commandType: CommandType.StoredProcedure);
                return item;
            }
        }
    }
}