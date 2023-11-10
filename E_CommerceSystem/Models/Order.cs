using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NuGet.Packaging.PackagingConstants;

namespace E_CommerceSystem.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال تاريخ الطلب")]
        public DateTime OrderDate { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال الكمية")]
        public decimal TotalAmount { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال عنوان السوق")]
        public string ShippingAddress { get; set; }
        
        [Required(ErrorMessage = "يجب تحديد حالة الدفع")]
        public string PaymentStatus { get; set; }
        
        [Required(ErrorMessage = "يجب تحديد حالة الطلب")]
        public string OrderStatus { get; set; }

        
        // [Required(ErrorMessage = "يجب تحديد كود المستخدم")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User Users { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
