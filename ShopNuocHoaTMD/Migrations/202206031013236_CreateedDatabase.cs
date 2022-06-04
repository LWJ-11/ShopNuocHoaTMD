namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Advertisement",
                c => new
                    {
                        Adv_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Adv_Id);
            
            CreateTable(
                "dbo.tb_Brand",
                c => new
                    {
                        Brand_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Image = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Brand_Id);
            
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        Product_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Rate = c.Single(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Quanity = c.Int(nullable: false),
                        isHome = c.Boolean(nullable: false),
                        isFeature = c.Boolean(nullable: false),
                        isHot = c.Boolean(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Topic_Id = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Product_Id)
                .ForeignKey("dbo.tb_Brand", t => t.Brand_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Category", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Topic", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Brand_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.tb_OrderDetail",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Quanity = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        Delivery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id })
                .ForeignKey("dbo.tb_Order", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.tb_Order",
                c => new
                    {
                        Order_Id = c.Int(nullable: false, identity: true),
                        IsDelivered = c.Boolean(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveredDate = c.DateTime(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Delivery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_Id)
                .ForeignKey("dbo.tb_DeliveryMethod", t => t.Delivery_Id, cascadeDelete: true)
                .Index(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.tb_DeliveryMethod",
                c => new
                    {
                        Delivery_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.tb_ProductPrice",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Size_Id = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Size_Id })
                .ForeignKey("dbo.tb_Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Size", t => t.Size_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Size_Id);
            
            CreateTable(
                "dbo.tb_Size",
                c => new
                    {
                        Size_Id = c.Int(nullable: false, identity: true),
                        SizeValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Size_Id);
            
            CreateTable(
                "dbo.tb_Topic",
                c => new
                    {
                        Topic_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Image = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Topic_Id);
            
            CreateTable(
                "dbo.tb_Menu",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 4000),
                        Position = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Menu_Id);
            
            CreateTable(
                "dbo.tb_MenuDetail",
                c => new
                    {
                        Detail_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Link = c.String(maxLength: 200),
                        Menu_Id = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Detail_Id)
                .ForeignKey("dbo.tb_Menu", t => t.Menu_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_MenuDetail", "Menu_Id", "dbo.tb_Menu");
            DropForeignKey("dbo.tb_Product", "Topic_Id", "dbo.tb_Topic");
            DropForeignKey("dbo.tb_ProductPrice", "Size_Id", "dbo.tb_Size");
            DropForeignKey("dbo.tb_ProductPrice", "Product_Id", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "Product_Id", "dbo.tb_Product");
            DropForeignKey("dbo.tb_OrderDetail", "Order_Id", "dbo.tb_Order");
            DropForeignKey("dbo.tb_Order", "Delivery_Id", "dbo.tb_DeliveryMethod");
            DropForeignKey("dbo.tb_Product", "Category_Id", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Product", "Brand_Id", "dbo.tb_Brand");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_MenuDetail", new[] { "Menu_Id" });
            DropIndex("dbo.tb_ProductPrice", new[] { "Size_Id" });
            DropIndex("dbo.tb_ProductPrice", new[] { "Product_Id" });
            DropIndex("dbo.tb_Order", new[] { "Delivery_Id" });
            DropIndex("dbo.tb_OrderDetail", new[] { "Product_Id" });
            DropIndex("dbo.tb_OrderDetail", new[] { "Order_Id" });
            DropIndex("dbo.tb_Product", new[] { "Topic_Id" });
            DropIndex("dbo.tb_Product", new[] { "Category_Id" });
            DropIndex("dbo.tb_Product", new[] { "Brand_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_MenuDetail");
            DropTable("dbo.tb_Menu");
            DropTable("dbo.tb_Topic");
            DropTable("dbo.tb_Size");
            DropTable("dbo.tb_ProductPrice");
            DropTable("dbo.tb_DeliveryMethod");
            DropTable("dbo.tb_Order");
            DropTable("dbo.tb_OrderDetail");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_Brand");
            DropTable("dbo.tb_Advertisement");
        }
    }
}
