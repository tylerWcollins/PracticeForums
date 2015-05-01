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
                        UserID = c.String(nullable: false, maxLength: 128),
                        ThreadID = c.Int(nullable: false),
                        Message = c.String(),
                        PostTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ThreadID })
                .ForeignKey("dbo.Threads", t => t.ThreadID, cascadeDelete: true)
                .Index(t => t.ThreadID);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        UserID = c.String(),
                        PostTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ThreadID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ThreadID", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadID" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Comments");
        }
    }
}
