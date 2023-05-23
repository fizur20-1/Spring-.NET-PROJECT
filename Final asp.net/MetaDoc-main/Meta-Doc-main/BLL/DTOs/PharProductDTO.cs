using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PharProductDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Pharmacy_Id { get; set; }
    }
}
