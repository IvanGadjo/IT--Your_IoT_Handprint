namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantityNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Quantity", c => c.Int(nullable: false));
        }
    }
}
