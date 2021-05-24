namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChairConsists", "Id", "dbo.Activities");
            DropColumn("dbo.ChairConsists", "ActivityId");
            DropColumn("dbo.Chairs", "ContactId");
            RenameColumn(table: "dbo.Chairs", name: "Id", newName: "ContactId");
            RenameColumn(table: "dbo.ChairConsists", name: "Id", newName: "ActivityId");
            RenameIndex(table: "dbo.ChairConsists", name: "IX_Id", newName: "IX_ActivityId");
            RenameIndex(table: "dbo.Chairs", name: "IX_Id", newName: "IX_ContactId");
            DropPrimaryKey("dbo.ChairConsists");
            CreateTable(
                "dbo.CalendarOfEvents",
                c => new
                    {
                        EventReportId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Event = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.EventReportId)
                .ForeignKey("dbo.EventReports", t => t.EventReportId)
                .Index(t => t.EventReportId);
            
            CreateTable(
                "dbo.EventReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Report = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        MaterialSupportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialSupports", t => t.MaterialSupportId, cascadeDelete: true)
                .Index(t => t.MaterialSupportId);
            
            CreateTable(
                "dbo.MaterialSupports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ChairId = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .Index(t => t.Chair_ContactId);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FieldOfEducationId = c.Int(nullable: false),
                        ChairConsistId = c.Int(nullable: false),
                        EducationField_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChairConsists", t => t.ChairConsistId, cascadeDelete: true)
                .ForeignKey("dbo.EducationFields", t => t.EducationField_Id)
                .Index(t => t.ChairConsistId)
                .Index(t => t.EducationField_Id);
            
            CreateTable(
                "dbo.EducationFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ChairId = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .Index(t => t.Chair_ContactId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DocumentType = c.String(),
                        DocumentDate = c.String(),
                        DocumentNumber = c.Int(nullable: false),
                        ChairId = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .Index(t => t.Chair_ContactId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        ChairID = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .Index(t => t.Chair_ContactId);
            
            CreateTable(
                "dbo.TechnicalFacilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Configuration = c.String(),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId);
            
            AddColumn("dbo.ChairConsists", "ChairId", c => c.Int(nullable: false));
            AddColumn("dbo.ChairConsists", "Chair_ContactId", c => c.Int());
            AlterColumn("dbo.ChairConsists", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ChairConsists", "Id");
            CreateIndex("dbo.ChairConsists", "Chair_ContactId");
            AddForeignKey("dbo.ChairConsists", "Chair_ContactId", "dbo.Chairs", "ContactId");
            AddForeignKey("dbo.ChairConsists", "ActivityId", "dbo.Activities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChairConsists", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.TechnicalFacilities", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Posts", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Documents", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Disciplines", "EducationField_Id", "dbo.EducationFields");
            DropForeignKey("dbo.EducationFields", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Disciplines", "ChairConsistId", "dbo.ChairConsists");
            DropForeignKey("dbo.Classrooms", "MaterialSupportId", "dbo.MaterialSupports");
            DropForeignKey("dbo.MaterialSupports", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.ChairConsists", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.CalendarOfEvents", "EventReportId", "dbo.EventReports");
            DropIndex("dbo.TechnicalFacilities", new[] { "ClassroomId" });
            DropIndex("dbo.Posts", new[] { "Chair_ContactId" });
            DropIndex("dbo.Documents", new[] { "Chair_ContactId" });
            DropIndex("dbo.EducationFields", new[] { "Chair_ContactId" });
            DropIndex("dbo.Disciplines", new[] { "EducationField_Id" });
            DropIndex("dbo.Disciplines", new[] { "ChairConsistId" });
            DropIndex("dbo.MaterialSupports", new[] { "Chair_ContactId" });
            DropIndex("dbo.Classrooms", new[] { "MaterialSupportId" });
            DropIndex("dbo.ChairConsists", new[] { "Chair_ContactId" });
            DropIndex("dbo.CalendarOfEvents", new[] { "EventReportId" });
            DropPrimaryKey("dbo.ChairConsists");
            AlterColumn("dbo.ChairConsists", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ChairConsists", "Chair_ContactId");
            DropColumn("dbo.ChairConsists", "ChairId");
            DropTable("dbo.TechnicalFacilities");
            DropTable("dbo.Posts");
            DropTable("dbo.Documents");
            DropTable("dbo.EducationFields");
            DropTable("dbo.Disciplines");
            DropTable("dbo.MaterialSupports");
            DropTable("dbo.Classrooms");
            DropTable("dbo.EventReports");
            DropTable("dbo.CalendarOfEvents");
            AddPrimaryKey("dbo.ChairConsists", "Id");
            RenameIndex(table: "dbo.Chairs", name: "IX_ContactId", newName: "IX_Id");
            RenameIndex(table: "dbo.ChairConsists", name: "IX_ActivityId", newName: "IX_Id");
            RenameColumn(table: "dbo.ChairConsists", name: "ActivityId", newName: "Id");
            RenameColumn(table: "dbo.Chairs", name: "ContactId", newName: "Id");
            AddColumn("dbo.Chairs", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.ChairConsists", "ActivityId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ChairConsists", "Id", "dbo.Activities", "Id");
        }
    }
}
