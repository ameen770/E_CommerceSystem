using System.ComponentModel.DataAnnotations;

namespace E_CommerceSystem.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال أسم الفئة")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "يجب إدخال الوصف")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
