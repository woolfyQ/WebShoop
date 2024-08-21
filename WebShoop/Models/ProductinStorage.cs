using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class ProductinStorage
    {
        [Key]
        public Guid Id { get; set; }
        public int Amount { get; set; }    
        public Product Product { get; set; }
    }
}
