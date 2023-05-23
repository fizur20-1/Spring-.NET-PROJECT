using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Doctor
    {
        //[Key, Range(2000,2999)]
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get;set; }
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Degree { get; set; }
        public string Chamber { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        public virtual ICollection<DiseaseSymptom> DiseaseSymptoms { get; set; }
        public Doctor()
        {
            Reviews = new List<Review>();
            PatientAppointments = new List<PatientAppointment>();
            DiseaseSymptoms = new List<DiseaseSymptom>();
        }
    }
}
