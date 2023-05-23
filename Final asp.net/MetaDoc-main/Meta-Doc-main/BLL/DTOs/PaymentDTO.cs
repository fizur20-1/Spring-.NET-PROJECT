using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Status { get { return Status; } set { Status = "unpaid"; } }
        public DateTime PaymentDate { get; set; }

        public int Patient_Id { get; set; }
    }
}
