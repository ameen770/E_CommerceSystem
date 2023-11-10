using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSystem.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        
        //[Required]
        public int? OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }

        
        //[Required]
        public int? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}
