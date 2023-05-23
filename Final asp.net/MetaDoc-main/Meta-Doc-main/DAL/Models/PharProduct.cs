using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PharProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        [ForeignKey("Pharmacy")]
        public int Pharmacy_Id { get; set; }

        public virtual Product Product { get; set; }
        public virtual Pharmacy Pharmacy { get;set; }

        //more property needed
    }
}
