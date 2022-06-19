namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductPrice", "Product_Id", "dbo.tb_Product");
            DropForeignKey("dbo.tb_ProductPrice", "Size_Id", "dbo.tb_Size");
            DropIndex("dbo.tb_ProductPrice", new[] { "Product_Id" });
            DropIndex("dbo.tb_ProductPrice", new[] { "Size_Id" });
            AddColumn("dbo.tb_Product", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "Size", c => c.Int(nullable: false));
            DropTable("dbo.tb_ProductPrice");
            DropTable("dbo.tb_Size");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Size",
                c => new
                    {
                        Size_Id = c.Int(nullable: false, identity: true),
                        SizeValue = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Size_Id);
            
            CreateTable(
                "dbo.tb_ProductPrice",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Size_Id = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Size_Id });
            
            DropColumn("dbo.tb_Product", "Size");
            DropColumn("dbo.tb_Product", "Price");
            CreateIndex("dbo.tb_ProductPrice", "Size_Id");
            CreateIndex("dbo.tb_ProductPrice", "Product_Id");
            AddForeignKey("dbo.tb_ProductPrice", "Size_Id", "dbo.tb_Size", "Size_Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_ProductPrice", "Product_Id", "dbo.tb_Product", "Product_Id", cascadeDelete: true);
        }
    }
}
