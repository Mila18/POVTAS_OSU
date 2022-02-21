namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEventReports : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarOfEvents", "EventReportId", "dbo.EventReports");
            DropIndex("dbo.CalendarOfEvents", new[] { "EventReportId" });
            DropPrimaryKey("dbo.CalendarOfEvents");
            AddColumn("dbo.CalendarOfEvents", "ReportFile", c => c.String());
            AlterColumn("dbo.CalendarOfEvents", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CalendarOfEvents", "Id");
            DropColumn("dbo.CalendarOfEvents", "EventReportId");
            DropTable("dbo.EventReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportFile = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CalendarOfEvents", "EventReportId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.CalendarOfEvents");
            AlterColumn("dbo.CalendarOfEvents", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.CalendarOfEvents", "ReportFile");
            AddPrimaryKey("dbo.CalendarOfEvents", "EventReportId");
            CreateIndex("dbo.CalendarOfEvents", "EventReportId");
            AddForeignKey("dbo.CalendarOfEvents", "EventReportId", "dbo.EventReports", "Id");
        }
    }
}
