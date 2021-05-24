namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MtoM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disciplines", "ChairConsistId", "dbo.ChairConsists");
            DropIndex("dbo.Disciplines", new[] { "ChairConsistId" });
            CreateTable(
                "dbo.DisciplineChairConsists",
                c => new
                    {
                        Discipline_Id = c.Int(nullable: false),
                        ChairConsist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discipline_Id, t.ChairConsist_Id })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.ChairConsists", t => t.ChairConsist_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id)
                .Index(t => t.ChairConsist_Id);
            
            DropColumn("dbo.Disciplines", "ChairConsistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplines", "ChairConsistId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DisciplineChairConsists", "ChairConsist_Id", "dbo.ChairConsists");
            DropForeignKey("dbo.DisciplineChairConsists", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.DisciplineChairConsists", new[] { "ChairConsist_Id" });
            DropIndex("dbo.DisciplineChairConsists", new[] { "Discipline_Id" });
            DropTable("dbo.DisciplineChairConsists");
            CreateIndex("dbo.Disciplines", "ChairConsistId");
            AddForeignKey("dbo.Disciplines", "ChairConsistId", "dbo.ChairConsists", "Id", cascadeDelete: true);
        }
    }
}
