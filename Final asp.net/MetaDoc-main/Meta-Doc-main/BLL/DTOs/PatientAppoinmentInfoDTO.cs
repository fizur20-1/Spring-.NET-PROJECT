using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PatientAppoinmentInfoDTO : PatientDTO
    {
        public List<PatientAppoinmentDTO> PatientAppoinments { get; set; }
        public PatientAppoinmentInfoDTO()
        {
            PatientAppoinments = new List<PatientAppoinmentDTO>();
        }
    }
}
