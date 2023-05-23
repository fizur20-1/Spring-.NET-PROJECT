namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MetaDocContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.MetaDocContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Random random = new Random();

            //for (int i = 1; i <= 1; i++)
            //{
            //    context.Doctors.AddOrUpdate(new Models.Doctor
            //    {
            //        Name = "DR." + Guid.NewGuid().ToString().Substring(0, 15),
            //        Email = Guid.NewGuid().ToString().Substring(0, 6) + "@gmail.com",
            //        Contact = "01" + random.Next(111111111, 999999999),
            //        Username = Guid.NewGuid().ToString().Substring(0, 8),
            //        Password = Guid.NewGuid().ToString().Substring(0, 10),
            //        Degree = "MBBS",
            //        Chamber = "Dhaka"
            //    });
            //}

            //for (int i = 1; i <= 15; i++)
            //{
            //    context.Patients.AddOrUpdate(new Models.Patient
            //    {
            //        Name = Guid.NewGuid().ToString().Substring(0, 20),
            //        Email = Guid.NewGuid().ToString().Substring(0, 6) + "@gmail.com",
            //        Contact = "01" + random.Next(111111111, 999999999),
            //        Username = Guid.NewGuid().ToString().Substring(0, 8),
            //        Password = Guid.NewGuid().ToString().Substring(0, 10),
            //        Age = random.Next(17, 65),
            //        Gender = "Male",
            //        Profession = Guid.NewGuid().ToString().Substring(0, 7)
            //    });
            //}

            //for (int i = 1; i <=5; i++)
            //{
            //    context.Pharmacies.AddOrUpdate(new Models.Pharmacy
            //    {
            //        Name = Guid.NewGuid().ToString().Substring(0, 20),
            //        Username = Guid.NewGuid().ToString().Substring(0, 8),
            //        Password = Guid.NewGuid().ToString().Substring(0, 10),
            //        Location = "Dhaka"
            //    });
            //}

            //for (int i = 1; i <= 15; i++)
            //{
            //    context.Reviews.AddOrUpdate(new Models.Review
            //    {
            //        Description = Guid.NewGuid().ToString(),
            //        Patient_Id = random.Next(16, 30),
            //        Doctor_Id = random.Next(11, 20)
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.DiseaseSymptoms.AddOrUpdate(new Models.DiseaseSymptom
            //    {
            //        Name = "Cardio_" + Guid.NewGuid().ToString().Substring(0, 5) + "_" + random.Next(1,5),
            //        Symptoms = Guid.NewGuid().ToString().Substring(0, 35),
            //        Catagory = Guid.NewGuid().ToString().Substring(0, 10),
            //        AppointmentCost = random.Next(1000, 3000),
            //        Doctor_Id = random.Next(11,20)
            //    });
            //}

            //for (int i = 1; i <= 15; i++)
            //{
            //    context.PatientAppointments.AddOrUpdate(new Models.PatientAppointment
            //    {
            //        AppointmentDate = DateTime.Now.AddHours(i),
            //        Doctor_Id = random.Next(11, 20),
            //        Patient_Id = random.Next(16, 30),
            //        Status = "Approve"
            //    });
            //}

            //for (int i = 1; i <= 15; i++)
            //{
            //    context.Payments.AddOrUpdate(new Models.Payment
            //    {
            //        Status = "Unpaid",
            //        PaymentDate = DateTime.Now.AddHours(i),
            //        Patient_Id = random.Next(16, 30),
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.Orders.AddOrUpdate(new Models.Order
            //    {
            //        OrderQuantity = random.Next(1,10),
            //        OrderDate = DateTime.Now.AddHours(i),
            //        TotalCost = random.Next(1,7) * random.Next(20, 150),
            //        Pharmacy_Id = random.Next(2,6),
            //        Patient_Id = random.Next(16, 30)
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.Products.AddOrUpdate(new Models.Product
            //    {
            //        ProductName = "Paracetamol_" + Guid.NewGuid().ToString().Substring(0, 10),
            //        Quantity = random.Next(20, 50),
            //        UnitPrice = random.Next(20, 150)
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.OrderDetails.AddOrUpdate(new Models.OrderDetail
            //    {
            //        Order_Id = random.Next(1, 10),
            //        Product_Id = random.Next(1, 10),
            //    });
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.PharProducts.AddOrUpdate(new Models.PharProduct
            //    {
            //        Pharmacy_Id = random.Next(2, 7),
            //        Product_Id = random.Next(1, 11),
            //    });
            //}
        }
    }
}
