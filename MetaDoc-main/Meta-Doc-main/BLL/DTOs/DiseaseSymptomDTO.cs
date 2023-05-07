using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DiseaseSymptomDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public string Catagory { get; set; }
        [Required]
        public int AppointmentCost { get; set; }


        public int Doctor_Id { get; set; }
    }
}
