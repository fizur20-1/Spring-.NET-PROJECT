namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB_modifyToken : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "User_Id", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "User_Id" });
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tokens", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
            CreateIndex("dbo.Tokens", "User_Id");
            AddForeignKey("dbo.Tokens", "User_Id", "dbo.Users", "Username", cascadeDelete: true);
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Tokens", "User_Id", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "User_Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Tokens", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Name");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Tokens", "User_Id");
            AddForeignKey("dbo.Tokens", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
