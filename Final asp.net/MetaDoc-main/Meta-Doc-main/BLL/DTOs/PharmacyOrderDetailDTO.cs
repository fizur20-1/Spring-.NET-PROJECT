using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharmacyOrderDetailDTO : PharmacyDTO
    {
        public List<OrderDetailDTO> Reviews { get; set; }
        public PharmacyOrderDetailDTO()
        {
            Reviews = new List<OrderDetailDTO>();
        }
    }
}
