using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Profession { get; set; }

        //[ForeignKey("Pharmacy")]
        //public int Pharmacy_Id { get; set; }

        //public virtual Pharmacy Pharmacies { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        public Patient()
        {
            Reviews = new List<Review>();
            Payments = new List<Payment>();
            Orders = new List<Order>();
            PatientAppointments =  new List<PatientAppointment>();
        }
    }
}
