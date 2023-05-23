namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB_withoutSeedingDoctorPatientPharmacy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseSymptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Symptoms = c.String(nullable: false),
                        Catagory = c.String(nullable: false),
                        AppointmentCost = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Degree = c.String(nullable: false),
                        Chamber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        DiseaseSymptom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiseaseSymptoms", t => t.DiseaseSymptom_Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.DiseaseSymptom_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        Profession = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderQuantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        Pharmacy_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pharmacies", t => t.Pharmacy_Id, cascadeDelete: true)
                .Index(t => t.Pharmacy_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pharmacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DiseaseSymptoms", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientAppointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Reviews", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Reviews", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Payments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Orders", "Pharmacy_Id", "dbo.Pharmacies");
            DropForeignKey("dbo.Orders", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.PatientAppointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientAppointments", "DiseaseSymptom_Id", "dbo.DiseaseSymptoms");
            DropIndex("dbo.Tokens", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "Doctor_Id" });
            DropIndex("dbo.Reviews", new[] { "Patient_Id" });
            DropIndex("dbo.Payments", new[] { "Patient_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Patient_Id" });
            DropIndex("dbo.Orders", new[] { "Pharmacy_Id" });
            DropIndex("dbo.PatientAppointments", new[] { "DiseaseSymptom_Id" });
            DropIndex("dbo.PatientAppointments", new[] { "Patient_Id" });
            DropIndex("dbo.PatientAppointments", new[] { "Doctor_Id" });
            DropIndex("dbo.DiseaseSymptoms", new[] { "Doctor_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.Reviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Pharmacies");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientAppointments");
            DropTable("dbo.Doctors");
            DropTable("dbo.DiseaseSymptoms");
            DropTable("dbo.Admins");
        }
    }
}
