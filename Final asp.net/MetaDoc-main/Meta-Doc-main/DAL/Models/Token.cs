using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        //[Key, Range(5000,15000)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string TKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        public virtual User User { get; set; }
    }
}
