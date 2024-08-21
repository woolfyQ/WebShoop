using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }    
        public User User { get; set; }

        public Product ProductinCart { get; set; }   
    }
}
