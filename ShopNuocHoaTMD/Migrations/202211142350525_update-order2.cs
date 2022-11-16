namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Order", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "ModifiedBy");
            DropColumn("dbo.tb_Order", "ModifiedDate");
            DropColumn("dbo.tb_Order", "CreatedBy");
            DropColumn("dbo.tb_Order", "CreatedDate");
        }
    }
}
