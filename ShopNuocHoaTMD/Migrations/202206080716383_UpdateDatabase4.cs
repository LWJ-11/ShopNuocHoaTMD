namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Topic", "DetailTitle", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Topic", "DetailTitle");
        }
    }
}
