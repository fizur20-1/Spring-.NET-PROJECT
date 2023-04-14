using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Pharmacy
    {
        [Key] 
        public int Phar_Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
