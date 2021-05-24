namespace POVTAS_OSU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Disciplines : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disciplines", "EducationField_Id", "dbo.EducationFields");
            DropIndex("dbo.Disciplines", new[] { "EducationField_Id" });
            RenameColumn(table: "dbo.Disciplines", name: "EducationField_Id", newName: "EducationFieldId");
            AlterColumn("dbo.Disciplines", "EducationFieldId", c => c.Int(nullable: false));
            CreateIndex("dbo.Disciplines", "EducationFieldId");
            AddForeignKey("dbo.Disciplines", "EducationFieldId", "dbo.EducationFields", "Id", cascadeDelete: true);
            DropColumn("dbo.Disciplines", "FieldOfEducationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplines", "FieldOfEducationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Disciplines", "EducationFieldId", "dbo.EducationFields");
            DropIndex("dbo.Disciplines", new[] { "EducationFieldId" });
            AlterColumn("dbo.Disciplines", "EducationFieldId", c => c.Int());
            RenameColumn(table: "dbo.Disciplines", name: "EducationFieldId", newName: "EducationField_Id");
            CreateIndex("dbo.Disciplines", "EducationField_Id");
            AddForeignKey("dbo.Disciplines", "EducationField_Id", "dbo.EducationFields", "Id");
        }
    }
}
