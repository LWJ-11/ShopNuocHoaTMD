namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDelivereMethod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Delivery_Id", "dbo.tb_DeliveryMethod");
            DropIndex("dbo.tb_OrderDetail", new[] { "Delivery_Id" });
            DropColumn("dbo.tb_OrderDetail", "Delivery_Id");
            DropTable("dbo.tb_DeliveryMethod");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_DeliveryMethod",
                c => new
                    {
                        Delivery_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Delivery_Id);
            
            AddColumn("dbo.tb_OrderDetail", "Delivery_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_OrderDetail", "Delivery_Id");
            AddForeignKey("dbo.tb_OrderDetail", "Delivery_Id", "dbo.tb_DeliveryMethod", "Delivery_Id", cascadeDelete: true);
        }
    }
}
