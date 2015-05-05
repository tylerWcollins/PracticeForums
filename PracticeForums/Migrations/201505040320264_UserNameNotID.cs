namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameNotID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Id", "dbo.Threads");
            DropForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Id" });
            RenameColumn(table: "dbo.Comments", name: "Id", newName: "Thread_ThreadID");
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Threads");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Comments", "Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "CMessage", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "CPostTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Thread_Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Threads", "Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Threads", "TMessage", c => c.String());
            AlterColumn("dbo.Threads", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Comments", new[] { "Username", "CMessage" });
            AddPrimaryKey("dbo.Threads", new[] { "Id", "Username" });
            AddPrimaryKey("dbo.Users", new[] { "Id", "Username" });
            CreateIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            AddForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads", new[] { "Id", "Username" }, cascadeDelete: true);
            DropColumn("dbo.Comments", "Id");
            DropColumn("dbo.Comments", "Message");
            DropColumn("dbo.Comments", "PostTime");
            DropColumn("dbo.Threads", "Message");
            DropColumn("dbo.Threads", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "Id", c => c.String());
            AddColumn("dbo.Threads", "Message", c => c.String());
            AddColumn("dbo.Comments", "PostTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Message", c => c.String());
            AddColumn("dbo.Comments", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Threads");
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Threads", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Threads", "TMessage");
            DropColumn("dbo.Threads", "Username");
            DropColumn("dbo.Comments", "Thread_Username");
            DropColumn("dbo.Comments", "CPostTime");
            DropColumn("dbo.Comments", "CMessage");
            DropColumn("dbo.Comments", "Username");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Threads", "Id");
            AddPrimaryKey("dbo.Comments", new[] { "Id", "Id" });
            RenameColumn(table: "dbo.Comments", name: "Thread_ThreadID", newName: "Id");
            CreateIndex("dbo.Comments", "Id");
            AddForeignKey("dbo.Comments", new[] { "Thread_ThreadID", "Thread_Username" }, "dbo.Threads", new[] { "Id", "Username" }, cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Id", "dbo.Threads", "Id", cascadeDelete: true);
        }
    }
}
