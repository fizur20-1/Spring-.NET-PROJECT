using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin> AdminData()
        {
            return new AdminRepo();
        }
        public static IRepo<DiseaseSymptom, int, DiseaseSymptom> DiseaseSymptomData()
        {
            return new DiseaseSymptomRepo();
        }
        public static IRepo<Doctor, int, Doctor> DoctorData()
        {
            return new DoctorRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<OrderDetail, int, OrderDetail> OrderDetailData()
        {
            return new OrderDetailRepo();
        }
        public static IRepo<Patient, int, Patient> PatientData()
        {
            return new PatientRepo();
        }
        public static IRepo<PatientAppointment, int, PatientAppointment> PatientAppointmentData()
        {
            return new PatientAppointmentRepo();
        }
        public static IRepo<Payment, int, Payment> PaymentData()
        {
            return new PaymentRepo();
        }
        public static IRepo<Pharmacy, int, Pharmacy> PharmacyData()
        {
            return new PharmacyRepo();
        }
        public static IRepo<Product, int, Product> ProductData()
        {
            return new ProductRepo();
        }
        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }
        public static IRepo<PharProduct, int, PharProduct> PharProductData()
        {
            return new PharProductRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IDoctorLogin<Doctor, string> MatchDoctorData()
        {
            return new DoctorRepo();
        }
        public static IPatientLogin<Patient, string> MatchPatientData()
        {
            return new PatientRepo();
        }
        public static IPharmacyLogin<Pharmacy, string> MatchPharmacyData()
        {
            return new PharmacyRepo();
        }
        public static IAdminLogin<Admin, string> MatchAdminData()
        {
            return new AdminRepo();
        }
    }
}