using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PatientAppoinmentDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public int Doctor_Id { get; set; }
        //[ForeignKey("DiseaseSymptom")]
        //public int Disease_Id { get; set; }
 
        public int Patient_Id { get; set; }
    }
}
