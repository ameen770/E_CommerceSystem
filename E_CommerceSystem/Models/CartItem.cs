using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSystem.Models
{
    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال الكمية")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال السعر")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "يجب تحديد كود البطاقة")] 
        public int? CartID { get; set; }

        [ForeignKey("CartID")]
        public virtual Cart Carts { get; set; }

        //[Required(ErrorMessage = "يجب كود المنتج")]
        public int? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}
