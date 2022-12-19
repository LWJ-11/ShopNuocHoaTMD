namespace ShopNuocHoaTMD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Blog",
                c => new
                    {
                        Blog_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false),
                        CoverImage = c.String(nullable: false),
                        Alias = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_Blog");
        }
    }
}
