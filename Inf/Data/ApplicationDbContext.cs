using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core;
namespace WebShoop.Data
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }
        //public DbSet<Id> Id { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }  
        public DbSet<ProductCart> ProductInCarts { get; set;}
        public DbSet<ProductStorage> ProductInStorages { get; set;}
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Rating> Ratings { get; set;}
        
      

        
       


    }
}
