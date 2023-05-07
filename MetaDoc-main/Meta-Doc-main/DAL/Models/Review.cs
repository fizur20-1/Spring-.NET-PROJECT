using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        [ForeignKey("Doctor")]
        public int Doctor_Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
