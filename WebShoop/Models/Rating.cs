using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }

        public double Rate { get; set; }   
        public User User { get; set; }  
        public Product Product { get; set; }

    }
}
