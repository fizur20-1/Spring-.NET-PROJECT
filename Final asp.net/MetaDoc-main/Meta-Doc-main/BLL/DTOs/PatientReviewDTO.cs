using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PatientReviewDTO : PatientDTO
    {
        public List<ReviewDTO> Reviews { get; set; }
        public PatientReviewDTO()
        {
            Reviews = new List<ReviewDTO>();
        }
    }
}
