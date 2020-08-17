namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatorUsernameToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CreatorUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "CreatorUsername");
        }
    }
}
