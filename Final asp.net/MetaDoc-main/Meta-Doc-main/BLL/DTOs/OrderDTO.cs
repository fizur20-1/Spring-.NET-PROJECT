using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalCost { get; set; }
        //[ForeignKey("OrderDetail")]
        //public int OrderDetail_Id { get; set; }

        public int Pharmacy_Id { get; set; }

        public int Patient_Id { get; set; }

    }
}
