using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        //[ForeignKey("OrderDetail")]
        //public int OrderDetail_Id { get; set; }
        //[ForeignKey("Pharmacy")]
        //public int Pharmacy_Id { get; set; }
        //public virtual Pharmacy Pharmacy { get; set; }
        //public virtual OrderDetail OrderDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PharProduct> PharProducts { get; set; }
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
            PharProducts= new List<PharProduct>();
        }
    }
}
