using System;
using System.Linq;
using CSharpFunctionalExtensions;
using L7.Domain;
using Microsoft.EntityFrameworkCore;

namespace L7.Persistance.Repositories
{
    public abstract class Repository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : Entity
    {
        private readonly ShopContext context;
        protected readonly DbSet<T> enititesSet;

        protected Repository(ShopContext context)
        {
            this.context = context;
            enititesSet = context.Set<T>();
        }

        public Maybe<T> GetById(Guid id)
        {
            return enititesSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return enititesSet;
        }

        public void Add(T entity)
        {
            enititesSet.Add(entity);
        }

        public void Update(T entity)
        {
            enititesSet.Update(entity);
        }

        public void Delete(T entity)
        {
            enititesSet.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}