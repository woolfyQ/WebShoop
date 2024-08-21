using Microsoft.EntityFrameworkCore;
using WebShoop.Data;
using WebShoop.Models;

namespace WebShoop
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }   
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
