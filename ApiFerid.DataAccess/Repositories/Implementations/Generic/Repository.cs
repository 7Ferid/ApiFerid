using ApiFerid.Core.Entities.Common;
using ApiFerid.DataAccess.Context;
using ApiFerid.DataAccess.Repositories.Abstractions.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApiFerid.DataAccess.Repositories.Implementations.Generic
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           var result= await _context.Set<T>().AnyAsync(expression);
            return result;
        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
           var entity= _context.Set<T>().FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
