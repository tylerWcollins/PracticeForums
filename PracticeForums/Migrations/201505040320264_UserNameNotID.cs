namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameNotID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ThreadID", "dbo.Threads");
            DropForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadID" });
            RenameColumn(table: "dbo.Comments", name: "ThreadID", newName: "Thread_ThreadID");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Threads");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Comments", "Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "CMessage", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "CPostTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Thread_Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Threads", "Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Threads", "TMessage", c => c.String());
            AlterColumn("dbo.Threads", "ThreadID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Comments", new[] { "Username", "CMessage" });
            AddPrimaryKey("dbo.Threads", new[] { "ThreadID", "Username" });
            AddPrimaryKey("dbo.Users", new[] { "UserID", "Username" });
            CreateIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            AddForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads", new[] { "ThreadID", "Username" }, cascadeDelete: true);
            DropColumn("dbo.Comments", "UserID");
            DropColumn("dbo.Comments", "Message");
            DropColumn("dbo.Comments", "PostTime");
            DropColumn("dbo.Threads", "Message");
            DropColumn("dbo.Threads", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "UserID", c => c.String());
            AddColumn("dbo.Threads", "Message", c => c.String());
            AddColumn("dbo.Comments", "PostTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Message", c => c.String());
            AddColumn("dbo.Comments", "UserID", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Threads");
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Threads", "ThreadID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Threads", "TMessage");
            DropColumn("dbo.Threads", "Username");
            DropColumn("dbo.Comments", "Thread_Username");
            DropColumn("dbo.Comments", "CPostTime");
            DropColumn("dbo.Comments", "CMessage");
            DropColumn("dbo.Comments", "Username");
            AddPrimaryKey("dbo.Users", "UserID");
            AddPrimaryKey("dbo.Threads", "ThreadID");
            AddPrimaryKey("dbo.Comments", new[] { "UserID", "ThreadID" });
            RenameColumn(table: "dbo.Comments", name: "Thread_ThreadID", newName: "ThreadID");
            CreateIndex("dbo.Comments", "ThreadID");
            AddForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads", new[] { "ThreadID", "Username" }, cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ThreadID", "dbo.Threads", "ThreadID", cascadeDelete: true);
        }
    }
}
