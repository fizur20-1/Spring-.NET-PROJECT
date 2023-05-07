using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class DiseaseSymptom
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public string Catagory { get; set; }
        [Required]
        public int AppointmentCost { get; set; }

        [ForeignKey("Doctor")]
        public int Doctor_Id { get; set; }

        public virtual Doctor Doctor { get; set; }

        //public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        //public DiseaseSymptom()
        //{
        //    PatientAppointments = new List<PatientAppointment>();
        //}
    }
}