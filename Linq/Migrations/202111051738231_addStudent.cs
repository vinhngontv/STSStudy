namespace Linq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Sex = c.Boolean(nullable: false),
                        Yob = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
