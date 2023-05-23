using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharmacyOrderDTO : PharmacyDTO
    {
        public List<OrderDTO> Reviews { get; set; }
        public PharmacyOrderDTO()
        {
            Reviews = new List<OrderDTO>();
        }
    }
}
