namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntitySupportStaff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportStaffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        PatronymicName = c.String(),
                        WorkExperience = c.String(),
                        Education = c.String(),
                        Photo = c.String(nullable: false),
                        PositionId = c.Int(nullable: false),
                        ChairId = c.Int(nullable: false),
                        Chair_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chairs", t => t.Chair_ContactId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.Chair_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportStaffs", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.SupportStaffs", "Chair_ContactId", "dbo.Chairs");
            DropIndex("dbo.SupportStaffs", new[] { "Chair_ContactId" });
            DropIndex("dbo.SupportStaffs", new[] { "PositionId" });
            DropTable("dbo.SupportStaffs");
        }
    }
}
