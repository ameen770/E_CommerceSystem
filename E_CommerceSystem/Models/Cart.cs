using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSystem.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        public int ID { get; set; }

        public DateTime CreationDate { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال الكمية")]
        public decimal TotalAmount { get; set; }

        //[Required(ErrorMessage = "يجب تحديد كود المستخدم")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User Users { get; set; }
        
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
