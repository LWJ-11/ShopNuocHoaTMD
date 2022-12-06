namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav_list : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteProducts",
                c => new
                    {
                        Fav_Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Fav_Id);
            
            CreateTable(
                "dbo.FavoriteProductProducts",
                c => new
                    {
                        FavoriteProduct_Fav_Id = c.Int(nullable: false),
                        Product_Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FavoriteProduct_Fav_Id, t.Product_Product_Id })
                .ForeignKey("dbo.FavoriteProducts", t => t.FavoriteProduct_Fav_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.Product_Product_Id, cascadeDelete: true)
                .Index(t => t.FavoriteProduct_Fav_Id)
                .Index(t => t.Product_Product_Id);
            
            CreateTable(
                "dbo.ApplicationUserFavoriteProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        FavoriteProduct_Fav_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.FavoriteProduct_Fav_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.FavoriteProducts", t => t.FavoriteProduct_Fav_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.FavoriteProduct_Fav_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserFavoriteProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts");
            DropForeignKey("dbo.ApplicationUserFavoriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteProductProducts", "Product_Product_Id", "dbo.tb_Product");
            DropForeignKey("dbo.FavoriteProductProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts");
            DropIndex("dbo.ApplicationUserFavoriteProducts", new[] { "FavoriteProduct_Fav_Id" });
            DropIndex("dbo.ApplicationUserFavoriteProducts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FavoriteProductProducts", new[] { "Product_Product_Id" });
            DropIndex("dbo.FavoriteProductProducts", new[] { "FavoriteProduct_Fav_Id" });
            DropTable("dbo.ApplicationUserFavoriteProducts");
            DropTable("dbo.FavoriteProductProducts");
            DropTable("dbo.FavoriteProducts");
        }
    }
}
