namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcademicTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.ChairConsists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        PatronymicName = c.String(),
                        WorkExperience = c.String(),
                        ActivityId = c.Int(nullable: false),
                        AcademicTitleId = c.Int(nullable: false),
                        AcademicDegreeId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        ChairId = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicDegrees", t => t.AcademicDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.AcademicTitles", t => t.AcademicTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.AcademicTitleId)
                .Index(t => t.AcademicDegreeId)
                .Index(t => t.PositionId)
                .Index(t => t.Chair_ContactId);
            
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ContactId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PositionKey = c.String(),
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TechnicalFacilities", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Posts", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Documents", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Disciplines", "EducationField_Id", "dbo.EducationFields");
            DropForeignKey("dbo.EducationFields", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Disciplines", "ChairConsistId", "dbo.ChairConsists");
            DropForeignKey("dbo.Classrooms", "MaterialSupportId", "dbo.MaterialSupports");
            DropForeignKey("dbo.MaterialSupports", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.ChairConsists", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.ChairConsists", "Chair_ContactId", "dbo.Chairs");
            DropForeignKey("dbo.Chairs", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ChairConsists", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.ChairConsists", "AcademicTitleId", "dbo.AcademicTitles");
            DropForeignKey("dbo.ChairConsists", "AcademicDegreeId", "dbo.AcademicDegrees");
            DropForeignKey("dbo.CalendarOfEvents", "EventReportId", "dbo.EventReports");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TechnicalFacilities", new[] { "ClassroomId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Posts", new[] { "Chair_ContactId" });
            DropIndex("dbo.Documents", new[] { "Chair_ContactId" });
            DropIndex("dbo.EducationFields", new[] { "Chair_ContactId" });
            DropIndex("dbo.Disciplines", new[] { "EducationField_Id" });
            DropIndex("dbo.Disciplines", new[] { "ChairConsistId" });
            DropIndex("dbo.MaterialSupports", new[] { "Chair_ContactId" });
            DropIndex("dbo.Classrooms", new[] { "MaterialSupportId" });
            DropIndex("dbo.Chairs", new[] { "ContactId" });
            DropIndex("dbo.ChairConsists", new[] { "Chair_ContactId" });
            DropIndex("dbo.ChairConsists", new[] { "PositionId" });
            DropIndex("dbo.ChairConsists", new[] { "AcademicDegreeId" });
            DropIndex("dbo.ChairConsists", new[] { "AcademicTitleId" });
            DropIndex("dbo.ChairConsists", new[] { "ActivityId" });
            DropIndex("dbo.CalendarOfEvents", new[] { "EventReportId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TechnicalFacilities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.Documents");
            DropTable("dbo.EducationFields");
            DropTable("dbo.Disciplines");
            DropTable("dbo.MaterialSupports");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Positions");
            DropTable("dbo.Contacts");
            DropTable("dbo.Chairs");
            DropTable("dbo.ChairConsists");
            DropTable("dbo.EventReports");
            DropTable("dbo.CalendarOfEvents");
            DropTable("dbo.Activities");
            DropTable("dbo.AcademicTitles");
            DropTable("dbo.AcademicDegrees");
        }
    }
}
