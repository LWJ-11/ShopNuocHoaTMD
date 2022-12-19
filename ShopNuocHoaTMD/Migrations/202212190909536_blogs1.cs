namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Blog", "Author", c => c.String(nullable: false));
            DropColumn("dbo.tb_Blog", "Alias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Blog", "Alias", c => c.String());
            DropColumn("dbo.tb_Blog", "Author");
        }
    }
}
