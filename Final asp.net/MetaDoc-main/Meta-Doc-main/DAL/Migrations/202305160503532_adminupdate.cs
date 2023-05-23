namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Name");
        }
    }
}
