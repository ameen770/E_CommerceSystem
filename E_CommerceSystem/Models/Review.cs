using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSystem.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; }

        
        //[Required]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User Users { get; set; }

        
        //[Required]
        public int? ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}
