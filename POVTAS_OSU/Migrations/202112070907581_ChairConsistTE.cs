namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChairConsistTE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChairConsists", "TeachingExperience", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChairConsists", "TeachingExperience");
        }
    }
}
