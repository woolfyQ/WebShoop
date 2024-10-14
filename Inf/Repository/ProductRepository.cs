using Core;
using Core.Entities;
using WebShoop.Data;

namespace Infrastructure.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product entity, CancellationToken cancellationToken)
        {
            var product = entity as Product;
            if (product == null)
            {
                throw new Exception("User not found");
            }
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Create(IEnumerable<Product> entity, CancellationToken cancellationToken)
        {
            var product = entity.OfType<Product>().ToList();
            await _context.Products.AddRangeAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task Update(Product entity, CancellationToken cancellationToken)
        {
            var products = entity as Product;
            if (products == null)
            {
                throw new Exception("User not found");
            }
            _context.Products.Update(products);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(IEnumerable<Product> entities, CancellationToken cancellationToken)
        {
            var product = entities.OfType<Product>().ToList();
            await _context.Products.AddRangeAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Product entity, CancellationToken cancellationToken)
        {
            var products = entity as Product;
            if (products == null)
            {
                throw new Exception("User not found");
            }
            _context.Products.Remove(products);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(IEnumerable<Product> entity, CancellationToken cancellationToken)
        {
            var products = entity.OfType<Product>().ToList();
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid Id)
        {
            return await _context.Products.FindAsync(Id);
        }


    }
}
