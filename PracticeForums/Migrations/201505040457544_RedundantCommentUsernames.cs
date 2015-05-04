namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedundantCommentUsernames : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", "CMessage");
            DropColumn("dbo.Comments", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Username", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", new[] { "CMessage", "Username" });
        }
    }
}
