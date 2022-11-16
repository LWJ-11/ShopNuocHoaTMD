namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_productStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductStock", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.tb_ProductStock", "Quanity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductStock", "Quanity", c => c.Int(nullable: false));
            DropColumn("dbo.tb_ProductStock", "Quantity");
        }
    }
}
