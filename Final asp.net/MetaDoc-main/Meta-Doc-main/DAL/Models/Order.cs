using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalCost { get; set; }
        //[ForeignKey("OrderDetail")]
        //public int OrderDetail_Id { get; set; }
        [ForeignKey("Pharmacy")]
        public int Pharmacy_Id { get; set; }
        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }

        //public virtual OrderDetail OrderDetail { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Patient Patient { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        //public Order() 
        //{ 
        //    Products = new List<Product>();
        //}
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
