namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderHistory2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_OrderDetail", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.tb_Order", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Order", "ApplicationUser_Id");
            AddForeignKey("dbo.tb_Order", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.tb_OrderDetail", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tb_Order", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.tb_Order", "ApplicationUser_Id");
            CreateIndex("dbo.tb_OrderDetail", "ApplicationUser_Id");
            AddForeignKey("dbo.tb_OrderDetail", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
