using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class ProductinCart
    {
        [Key]
        public Guid Id { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; } 




    }
}
