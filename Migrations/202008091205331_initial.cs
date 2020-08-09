namespace Your_IoT_Handprint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvgRating = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        EventLinkUrl = c.String(),
                        Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128, nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedOn = c.DateTime(nullable: false),
                        RecipientAdress = c.String(),
                        ProjectId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvgRating = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        GithubRepoUrl = c.String(),
                        ForSale = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128, nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "ProjectId" });
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Projects");
            DropTable("dbo.Orders");
            DropTable("dbo.Events");
        }
    }
}
