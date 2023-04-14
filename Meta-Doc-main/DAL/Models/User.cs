using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key] 
        public int User_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        [ForeignKey("Pharmacy")]
        public int Phar_Id { get; set; }
    }
}
