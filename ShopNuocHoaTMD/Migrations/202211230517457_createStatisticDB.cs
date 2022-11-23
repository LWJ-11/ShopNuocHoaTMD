namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createStatisticDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Stat_Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        NumberOfVisits = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Stat_Id);
            
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
            DropTable("dbo.Statistics");
        }
    }
}
