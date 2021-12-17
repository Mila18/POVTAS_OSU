namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posts2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ViewsQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "NewsType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "NewsType");
            DropColumn("dbo.Posts", "ViewsQuantity");
        }
    }
}
