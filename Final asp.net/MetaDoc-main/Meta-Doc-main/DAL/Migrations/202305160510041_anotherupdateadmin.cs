namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherupdateadmin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Role", c => c.String(nullable: false));
        }
    }
}
