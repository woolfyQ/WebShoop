using System.ComponentModel.DataAnnotations;

namespace WebShoop.Models
{
    public class Storage
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    


    }
}
