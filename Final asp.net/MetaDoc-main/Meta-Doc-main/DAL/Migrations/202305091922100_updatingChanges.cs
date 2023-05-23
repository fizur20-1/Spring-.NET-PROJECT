namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tokens", name: "User_Id", newName: "Username");
            RenameIndex(table: "dbo.Tokens", name: "IX_User_Id", newName: "IX_Username");
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.Tokens", name: "IX_Username", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Tokens", name: "Username", newName: "User_Id");
        }
    }
}
