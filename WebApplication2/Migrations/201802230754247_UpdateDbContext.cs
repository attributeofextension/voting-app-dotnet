namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Votes = c.Int(),
                        PollId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polls", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropIndex("dbo.Polls", new[] { "User_Id" });
            DropIndex("dbo.Options", new[] { "PollId" });
            DropTable("dbo.Polls");
            DropTable("dbo.Options");
        }
    }
}
