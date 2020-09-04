namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserFKfromOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
