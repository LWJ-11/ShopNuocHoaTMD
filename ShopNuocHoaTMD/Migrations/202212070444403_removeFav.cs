namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFav : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavoriteProductProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts");
            DropForeignKey("dbo.FavoriteProductProducts", "Product_Product_Id", "dbo.tb_Product");
            DropForeignKey("dbo.ApplicationUserFavoriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserFavoriteProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts");
            DropIndex("dbo.FavoriteProductProducts", new[] { "FavoriteProduct_Fav_Id" });
            DropIndex("dbo.FavoriteProductProducts", new[] { "Product_Product_Id" });
            DropIndex("dbo.ApplicationUserFavoriteProducts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserFavoriteProducts", new[] { "FavoriteProduct_Fav_Id" });
            DropTable("dbo.FavoriteProducts");
            DropTable("dbo.FavoriteProductProducts");
            DropTable("dbo.ApplicationUserFavoriteProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserFavoriteProducts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        FavoriteProduct_Fav_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.FavoriteProduct_Fav_Id });
            
            CreateTable(
                "dbo.FavoriteProductProducts",
                c => new
                    {
                        FavoriteProduct_Fav_Id = c.Int(nullable: false),
                        Product_Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FavoriteProduct_Fav_Id, t.Product_Product_Id });
            
            CreateTable(
                "dbo.FavoriteProducts",
                c => new
                    {
                        Fav_Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Fav_Id);
            
            CreateIndex("dbo.ApplicationUserFavoriteProducts", "FavoriteProduct_Fav_Id");
            CreateIndex("dbo.ApplicationUserFavoriteProducts", "ApplicationUser_Id");
            CreateIndex("dbo.FavoriteProductProducts", "Product_Product_Id");
            CreateIndex("dbo.FavoriteProductProducts", "FavoriteProduct_Fav_Id");
            AddForeignKey("dbo.ApplicationUserFavoriteProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts", "Fav_Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserFavoriteProducts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FavoriteProductProducts", "Product_Product_Id", "dbo.tb_Product", "Product_Id", cascadeDelete: true);
            AddForeignKey("dbo.FavoriteProductProducts", "FavoriteProduct_Fav_Id", "dbo.FavoriteProducts", "Fav_Id", cascadeDelete: true);
        }
    }
}
