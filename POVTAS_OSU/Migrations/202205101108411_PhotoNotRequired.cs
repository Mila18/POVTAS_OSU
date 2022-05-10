namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChairConsists", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChairConsists", "Photo", c => c.String(nullable: false));
        }
    }
}
