namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdNowString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Polls", new[] { "User_Id" });
            DropColumn("dbo.Polls", "UserId");
            RenameColumn(table: "dbo.Polls", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Polls", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Polls", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Polls", new[] { "UserId" });
            AlterColumn("dbo.Polls", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Polls", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Polls", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Polls", "User_Id");
        }
    }
}
