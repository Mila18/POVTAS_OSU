namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_prop2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventReports", "ReportFile", c => c.String());
            AddColumn("dbo.ChairConsists", "Photo", c => c.String());
            AddColumn("dbo.Documents", "File", c => c.String());
            AlterColumn("dbo.Documents", "DocumentNumber", c => c.String());
            DropColumn("dbo.EventReports", "Report");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventReports", "Report", c => c.String());
            AlterColumn("dbo.Documents", "DocumentNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Documents", "File");
            DropColumn("dbo.ChairConsists", "Photo");
            DropColumn("dbo.EventReports", "ReportFile");
        }
    }
}
