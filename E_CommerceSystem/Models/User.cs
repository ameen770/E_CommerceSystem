using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Carts = new HashSet<Cart>();
            Reviews = new HashSet<Review>();
            Payments = new HashSet<Payment>();
            Wishlists = new HashSet<Wishlist>();
        }

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "يجب إدخال الأسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يجب إدخال الأيميل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يجب إدخال كلمة السر")]
        public string Password { get; set; }

        [Required(ErrorMessage = "يجب إدخال عنوان السكن")]
        public string Address { get; set; }

        [Required(ErrorMessage = "يجب إدخال رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "يجب إدخال معلومات الدفع")]
        public string PaymentInformation { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
