using Core.Entities;

namespace Core.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public decimal TotalPrice {  get; set; }
        
        public virtual ICollection<ProductCart> Products { get; set; }



    }
}
