namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB_PharProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PharProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Pharmacy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pharmacies", t => t.Pharmacy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Pharmacy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PharProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PharProducts", "Pharmacy_Id", "dbo.Pharmacies");
            DropIndex("dbo.PharProducts", new[] { "Pharmacy_Id" });
            DropIndex("dbo.PharProducts", new[] { "Product_Id" });
            DropTable("dbo.PharProducts");
        }
    }
}
