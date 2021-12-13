namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChairConsist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChairConsists", "Education", c => c.String());
            AddColumn("dbo.ChairConsists", "Details", c => c.String());
            AddColumn("dbo.ChairConsists", "Emails", c => c.String());
            AddColumn("dbo.ChairConsists", "Schedule", c => c.String());
            AddColumn("dbo.ChairConsists", "Training", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChairConsists", "Training");
            DropColumn("dbo.ChairConsists", "Schedule");
            DropColumn("dbo.ChairConsists", "Emails");
            DropColumn("dbo.ChairConsists", "Details");
            DropColumn("dbo.ChairConsists", "Education");
        }
    }
}
