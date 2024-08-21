using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Img { get; set; } 
    }
}
