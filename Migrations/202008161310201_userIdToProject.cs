namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdToProject : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Projects", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Projects", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
