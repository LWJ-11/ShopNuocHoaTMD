namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder_removeDeliveredDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "DeliveredDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "DeliveredDate", c => c.DateTime(nullable: false));
        }
    }
}
