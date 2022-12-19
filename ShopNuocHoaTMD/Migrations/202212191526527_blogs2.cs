namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogs2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Blog", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Blog", "Description");
        }
    }
}
