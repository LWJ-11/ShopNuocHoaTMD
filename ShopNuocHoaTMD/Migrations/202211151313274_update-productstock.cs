namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproductstock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductStock",
                c => new
                    {
                        Stock_Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Quanity = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Stock_Id)
                .ForeignKey("dbo.tb_Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.tb_Product", "Quanity");
            DropColumn("dbo.tb_Product", "Price");
            DropColumn("dbo.tb_Product", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.tb_Product", "Quanity", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_ProductStock", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductStock", new[] { "Product_Id" });
            DropTable("dbo.tb_ProductStock");
        }
    }
}
