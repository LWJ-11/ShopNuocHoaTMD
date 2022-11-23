namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStatistic : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Statistics", newName: "tb_Statistic");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_Statistic", newName: "Statistics");
        }
    }
}
