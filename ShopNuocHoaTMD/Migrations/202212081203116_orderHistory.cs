namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.tb_Order", "User_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.tb_OrderDetail", "ApplicationUser_Id");
            AddForeignKey("dbo.tb_OrderDetail", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_OrderDetail", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.tb_Order", "User_Id");
            DropColumn("dbo.tb_OrderDetail", "ApplicationUser_Id");
        }
    }
}
