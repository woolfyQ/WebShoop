using Core;
using Core.Entities;
using System.Diagnostics.Metrics;
using WebShoop.Data;


namespace Infrastructure
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create (IEntity entity, CancellationToken cancellationToken)
        {
            if (entity is Product product)
            {
                await _context.Products.AddAsync (product, cancellationToken); 
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Entity is not of type Product");
            }
        }
        public async Task Create (IEnumerable<IEntity> entities, CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await Create (entity, cancellationToken);
            }
        }
        public async Task Update(IEntity entity, CancellationToken cancellationToken)
        {
            if (entity is Product product)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Entity is not of type Product");
            }
        }
        
        public async Task Update(IEnumerable<IEntity> entities, CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await Update (entity, cancellationToken);
            }
            
        }
        
        public async Task Delete (IEntity entity, CancellationToken cancellationToken)
        {
            if (entity is Product product)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }   
        public async Task Delete (IEnumerable<IEntity> entities, CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await Delete (entity, cancellationToken);
            }
        }
      public async Task <Product> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(new object[] { Id }, cancellationToken);   

        }


            

    }
}
