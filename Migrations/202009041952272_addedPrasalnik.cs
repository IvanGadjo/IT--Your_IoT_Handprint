namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPrasalnik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Orders", new[] { "ProjectId" });
            AlterColumn("dbo.Orders", "ProjectId", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "ProjectId");
            AddForeignKey("dbo.Orders", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Orders", new[] { "ProjectId" });
            AlterColumn("dbo.Orders", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProjectId");
            AddForeignKey("dbo.Orders", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
