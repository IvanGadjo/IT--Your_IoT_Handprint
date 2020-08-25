namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListRatingsToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "AllRatingsString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "AllRatingsString");
        }
    }
}
