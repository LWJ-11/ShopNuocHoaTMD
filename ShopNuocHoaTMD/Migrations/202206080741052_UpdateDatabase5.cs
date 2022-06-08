namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Size", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Size", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Size", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Size", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Size", "ModifiedBy");
            DropColumn("dbo.tb_Size", "ModifiedDate");
            DropColumn("dbo.tb_Size", "CreatedBy");
            DropColumn("dbo.tb_Size", "CreatedDate");
        }
    }
}
