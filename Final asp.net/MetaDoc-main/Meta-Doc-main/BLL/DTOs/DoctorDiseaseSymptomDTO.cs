using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDiseaseSymptomDTO : PatientDTO
    {
        public List<DiseaseSymptomDTO> DiseaseSymptoms { get; set; }
        public DoctorDiseaseSymptomDTO()
        {
            DiseaseSymptoms = new List<DiseaseSymptomDTO>();
        }
    }
}
