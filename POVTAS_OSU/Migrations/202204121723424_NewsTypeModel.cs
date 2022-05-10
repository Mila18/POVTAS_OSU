namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "NewsTypeId", c => c.Int());
            CreateIndex("dbo.Posts", "NewsTypeId");
            AddForeignKey("dbo.Posts", "NewsTypeId", "dbo.NewsTypes", "Id");
            DropColumn("dbo.Posts", "NewsType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "NewsType", c => c.String());
            DropForeignKey("dbo.Posts", "NewsTypeId", "dbo.NewsTypes");
            DropIndex("dbo.Posts", new[] { "NewsTypeId" });
            DropColumn("dbo.Posts", "NewsTypeId");
            DropTable("dbo.NewsTypes");
        }
    }
}
