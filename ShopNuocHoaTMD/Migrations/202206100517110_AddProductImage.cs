namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        Image_Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Image_Id)
                .ForeignKey("dbo.tb_Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductImage", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "Product_Id" });
            DropTable("dbo.tb_ProductImage");
        }
    }
}
