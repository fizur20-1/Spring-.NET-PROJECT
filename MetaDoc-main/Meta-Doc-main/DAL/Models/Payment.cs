using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
