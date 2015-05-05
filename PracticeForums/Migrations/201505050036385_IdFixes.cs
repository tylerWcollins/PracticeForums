namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads");
            DropForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            RenameColumn(table: "dbo.Comments", name: "Thread_ThreadID", newName: "Thread_Id");
            DropPrimaryKey("dbo.Threads");
            DropColumn("dbo.Threads", "ThreadID");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "UserID");
            AddColumn("dbo.Comments", "CUsername", c => c.String());
            AddColumn("dbo.Threads", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Threads", "Username", c => c.String());
            AddPrimaryKey("dbo.Threads", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Comments", "Thread_Id");
            AddForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "Thread_Username");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Threads", "ThreadID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Thread_Username", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Threads");
            AlterColumn("dbo.Threads", "Username", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Threads", "Id");
            DropColumn("dbo.Comments", "CUsername");
            AddPrimaryKey("dbo.Users", "UserID");
            AddPrimaryKey("dbo.Threads", new[] { "ThreadID", "Username" });
            RenameColumn(table: "dbo.Comments", name: "Thread_Id", newName: "Thread_ThreadID");
            CreateIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            AddForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads", new[] { "ThreadID", "Username" }, cascadeDelete: true);
        }
    }
}
