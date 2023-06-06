using TravelGuide.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelGuide.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id)!;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity?> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate)!;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity) 
        {
            Context.Set<TEntity>().Update(entity);
        }

        public bool IsEmpty()
        {
            var test = GetAll().Any();
            return !GetAll().Any();
        }
    }
}
