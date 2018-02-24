namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnNulledOption : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropIndex("dbo.Options", new[] { "PollId" });
            AlterColumn("dbo.Options", "Votes", c => c.Int(nullable: false));
            AlterColumn("dbo.Options", "PollId", c => c.Int(nullable: false));
            CreateIndex("dbo.Options", "PollId");
            AddForeignKey("dbo.Options", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropIndex("dbo.Options", new[] { "PollId" });
            AlterColumn("dbo.Options", "PollId", c => c.Int());
            AlterColumn("dbo.Options", "Votes", c => c.Int());
            CreateIndex("dbo.Options", "PollId");
            AddForeignKey("dbo.Options", "PollId", "dbo.Polls", "Id");
        }
    }
}
