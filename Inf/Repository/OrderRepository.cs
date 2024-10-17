﻿using Core;
using Core.Entities;
using WebShoop.Data;

namespace Infrastructure.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Order entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Orders.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Create(IEnumerable<Order> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            await _context.Orders.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Order entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(IEnumerable<Order> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            _context.Orders.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Order entity, CancellationToken cancellationToken)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(IEnumerable<Order> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any()) throw new ArgumentNullException(nameof(entities));
            _context.Orders.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public Task<Order> GetByEmailAsync(string email)
        {
            throw new NotImplementedException(); 
        }
    }
}