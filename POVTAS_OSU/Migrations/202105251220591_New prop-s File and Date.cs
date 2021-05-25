namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewpropsFileandDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Date", c => c.String());
            AddColumn("dbo.Posts", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "File");
            DropColumn("dbo.Posts", "Date");
        }
    }
}
