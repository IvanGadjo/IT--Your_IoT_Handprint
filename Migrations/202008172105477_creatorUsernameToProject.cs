namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatorUsernameToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatorUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "CreatorUsername");
        }
    }
}
