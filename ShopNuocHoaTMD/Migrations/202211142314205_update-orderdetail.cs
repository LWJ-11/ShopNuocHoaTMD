namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_OrderDetail", "Price");
        }
    }
}
