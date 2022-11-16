namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdetail1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.tb_OrderDetail", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "TotalAmount", c => c.Double(nullable: false));
            DropColumn("dbo.tb_Order", "TotalAmount");
        }
    }
}
