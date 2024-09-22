using Core.Entities;


namespace Core.DTO
{
    public class WareHouseDTO
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }



        public static implicit operator WareHouseDTO(ProductStorage productStorage) => new()
        {
            Id = productStorage.Id,
            Amount = productStorage.Amount,
            Product = productStorage.Product,
        };
    }
}   
