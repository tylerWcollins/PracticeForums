namespace PracticeForums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameNotID2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Message", c => c.String());
            DropColumn("dbo.Threads", "TMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "TMessage", c => c.String());
            DropColumn("dbo.Threads", "Message");
        }
    }
}
