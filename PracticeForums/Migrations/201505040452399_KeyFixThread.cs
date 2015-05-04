namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyFixThread : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", new[] { "CMessage", "Username" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", new[] { "Username", "CMessage" });
        }
    }
}
