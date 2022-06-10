namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowHtml : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Image", c => c.String(nullable: false));
        }
    }
}
