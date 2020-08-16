namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameOnProjectAndEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Name", c => c.String());
            AddColumn("dbo.Projects", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Name");
            DropColumn("dbo.Events", "Name");
        }
    }
}
