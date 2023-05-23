using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorAppointmentDTO : DoctorDTO
    {
        public List<PatientAppoinmentDTO> PatientAppoinments { get; set; }
        public DoctorAppointmentDTO()
        {
            PatientAppoinments = new List<PatientAppoinmentDTO>();
        }
    }
}
