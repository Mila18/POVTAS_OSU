namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocTypeNewClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Documents", "DocumentTypeId", c => c.Int());
            CreateIndex("dbo.Documents", "DocumentTypeId");
            AddForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes", "Id");
            DropColumn("dbo.Documents", "DocumentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "DocumentType", c => c.String());
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropColumn("dbo.Documents", "DocumentTypeId");
            DropTable("dbo.DocumentTypes");
        }
    }
}
