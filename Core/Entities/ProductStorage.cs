using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductStorage : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Amount { get; set; }    
        public Product Product { get; set; }


    }
}
