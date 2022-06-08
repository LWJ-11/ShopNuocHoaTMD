namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataabse3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Topic", "Alias", c => c.String());
            DropColumn("dbo.tb_Category", "Alias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Category", "Alias", c => c.String());
            DropColumn("dbo.tb_Topic", "Alias");
        }
    }
}
