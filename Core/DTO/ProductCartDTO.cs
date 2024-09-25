using Core.Entities;

namespace Core.DTO
{
    public class ProductCartDTO
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }


        public static implicit operator ProductCartDTO(ProductCart productCart) => new()
        {
            Id = productCart.Id,
            Amount = productCart.Amount,
            Cart = productCart.Cart,
            Product = productCart.Product
        };


        // Преобразовать DTO сразу.

    }
}
