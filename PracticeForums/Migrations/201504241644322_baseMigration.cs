namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        //Id = c.Int(nullable: false),
                        Message = c.String(),
                        PostTime = c.DateTime(nullable: false),
                    })
                //.PrimaryKey(t => new { t.Id, t.Id })
                .ForeignKey("dbo.Threads", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        //Id = c.String(),
                        PostTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Comments");
        }
    }
}
