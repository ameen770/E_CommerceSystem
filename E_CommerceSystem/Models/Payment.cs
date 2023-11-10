using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSystem.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public decimal Amount { get; set; }

        //[Required]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User Users { get; set; }
 
        //[Required]
        public int? OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }
    }
}
