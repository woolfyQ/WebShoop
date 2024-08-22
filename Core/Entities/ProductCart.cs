namespace Core.Entities;

public class ProductCart
{
    public Guid Id { get; set; }
    public Cart Cart { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; } 

}
