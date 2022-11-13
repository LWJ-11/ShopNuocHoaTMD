namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_MenuDetail", "Menu_Id", "dbo.tb_Menu");
            DropIndex("dbo.tb_MenuDetail", new[] { "Menu_Id" });
            DropColumn("dbo.tb_OrderDetail", "Delivery_Id");
            DropTable("dbo.tb_MenuDetail");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Detail_Id);
            
            AddColumn("dbo.tb_OrderDetail", "Delivery_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_MenuDetail", "Menu_Id");
            AddForeignKey("dbo.tb_MenuDetail", "Menu_Id", "dbo.tb_Menu", "Menu_Id", cascadeDelete: true);
        }
    }
}
