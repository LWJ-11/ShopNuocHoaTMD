namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isbestseller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "isBestSeller", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "isBestSeller");
        }
    }
}
