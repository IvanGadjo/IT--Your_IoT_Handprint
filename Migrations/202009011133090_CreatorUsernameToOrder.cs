namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorUsernameToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreatorUsername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreatorUsername");
        }
    }
}
