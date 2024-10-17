using Core.Entities;
using Core;
using WebShoop.Data;

namespace Infrastructure.Repository
{
    public class StorageRepository : IRepository<ProductStorage>
    {
        private readonly ApplicationDbContext _context;

        public StorageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductStorage entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ProductStorages.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Create(IEnumerable<ProductStorage> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            await _context.ProductStorages.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(ProductStorage entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ProductStorages.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(IEnumerable<ProductStorage> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            _context.ProductStorages.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductStorage> GetByIdAsync(Guid id)
        {
            return await _context.ProductStorages.FindAsync(id);
        }

        public Task<ProductStorage> GetByEmailAsync(string email)
        {
            throw new NotImplementedException(); 
        }

        public async Task Update(ProductStorage entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ProductStorages.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(IEnumerable<ProductStorage> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            _context.ProductStorages.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}