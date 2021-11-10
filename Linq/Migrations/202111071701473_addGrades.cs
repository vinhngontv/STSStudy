namespace Linq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGrades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            AddColumn("dbo.Students", "GradeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "GradeId");
            AddForeignKey("dbo.Students", "GradeId", "dbo.Grades", "GradeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GradeId", "dbo.Grades");
            DropIndex("dbo.Students", new[] { "GradeId" });
            DropColumn("dbo.Students", "GradeId");
            DropTable("dbo.Grades");
        }
    }
}
