namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedata2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Advertisement", "Alias", c => c.String());
            DropColumn("dbo.tb_Advertisement", "Aliasc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Advertisement", "Aliasc", c => c.String());
            DropColumn("dbo.tb_Advertisement", "Alias");
        }
    }
}
