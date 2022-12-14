namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderHistory1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "User_Id", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "User_Id", c => c.Int(nullable: false));
        }
    }
}
