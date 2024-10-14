﻿using Core;
using Core.Entities;
using WebShoop.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(User entity, CancellationToken cancellationToken)
        {
            var user = entity as User;
            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken); 
        }

        public async Task Create(IEnumerable<User> entity, CancellationToken cancellationToken)
        {
            var users = entity.OfType<User>().ToList();
            await _context.Users.AddRangeAsync(users, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task Update(User entity, CancellationToken cancellationToken)
        {
            var users = entity as User;
            if(users == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Update(users);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(IEnumerable<User> entities, CancellationToken cancellationToken)
        {
           var users = entities.OfType<User>().ToList();
            await _context.Users.AddRangeAsync(users, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(User entity, CancellationToken cancellationToken)
        {
            var users = entity as User;
            if (users == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(users);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(IEnumerable<User> entity, CancellationToken cancellationToken)
        {
            var users = entity.OfType<User>().ToList();
            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(Guid Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
