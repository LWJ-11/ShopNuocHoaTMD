namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdetail3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            AddColumn("dbo.tb_OrderDetail", "OrderDetail_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_OrderDetail", "OrderDetail_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            DropColumn("dbo.tb_OrderDetail", "OrderDetail_Id");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "Order_Id", "Product_Id" });
        }
    }
}
