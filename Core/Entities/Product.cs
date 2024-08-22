using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Core.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string[] Img { get; set; }

    public string Specs { get; set; }

    public string Description { get; set; }


    
}
