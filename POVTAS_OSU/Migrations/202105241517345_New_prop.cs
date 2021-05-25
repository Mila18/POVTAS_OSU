namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_prop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classrooms", "Number");
        }
    }
}
