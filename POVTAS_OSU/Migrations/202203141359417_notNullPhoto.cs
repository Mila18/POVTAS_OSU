namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notNullPhoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChairConsists", "Photo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChairConsists", "Photo", c => c.String());
        }
    }
}
