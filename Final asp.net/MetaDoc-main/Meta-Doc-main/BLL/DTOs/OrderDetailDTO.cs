using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDetailDTO
    {

        public int Id { get; set; }

        public int Order_Id { get; set; }

        public int Product_Id { get; set; }
        //[ForeignKey("OrderDetail")]
        //public int OrderDetail_Id { get; set; }

        public int Pharmacy_Id { get; set; }

        public int Patient_Id { get; set; }
    }
}
