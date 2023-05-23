using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetaDocContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get;set; }
        public DbSet<Pharmacy> Pharmacies { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<DiseaseSymptom> DiseaseSymptoms { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PatientAppointment> PatientAppointments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<PharProduct> PharProducts { get; set; }
    }
}
