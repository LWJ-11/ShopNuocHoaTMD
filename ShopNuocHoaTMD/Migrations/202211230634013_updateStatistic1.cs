namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStatistic1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Statistic", "TimeStat", c => c.DateTime(nullable: false));
            DropColumn("dbo.tb_Statistic", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Statistic", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.tb_Statistic", "TimeStat");
        }
    }
}
