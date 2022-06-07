namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Advertisement", "Aliasc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Advertisement", "Aliasc");
        }
    }
}
