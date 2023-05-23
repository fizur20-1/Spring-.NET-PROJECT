using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorReviewDTO : DoctorDTO
    {
        public List<ReviewDTO> Reviews { get; set; }
        public DoctorReviewDTO()
        {
            Reviews = new List<ReviewDTO>();
        }
    }
}
