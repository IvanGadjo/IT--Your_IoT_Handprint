namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListRatingsToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AllRatingsString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "AllRatingsString");
        }
    }
}
