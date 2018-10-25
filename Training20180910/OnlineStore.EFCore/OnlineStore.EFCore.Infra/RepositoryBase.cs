using OnlineStore.EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.EFCore.Infra
{
    public abstract class RepositoryBase<TEntity>
        : IRepository<TEntity> 
        where TEntity : class
    {
        protected OnlineStoreDbContext context;
        public RepositoryBase(OnlineStoreDbContext context)
        {
            this.context = context;
        }
        public TEntity Create(TEntity newEntity)
        {
            context.Set<TEntity>()
                   .Add(newEntity);
            context.SaveChanges();
            return newEntity;
        }

        public async Task<TEntity> CreateAsync(TEntity newEntity)
        {
            await context.Set<TEntity>()
                   .AddAsync(newEntity);
            await context.SaveChangesAsync();
            return newEntity;
        }

        public void Delete(object key)
        {
            var entityToRemove = context.Set<TEntity>().Find(key);
            if (entityToRemove != null)
            {
                context.Set<TEntity>().Remove(entityToRemove);
                context.SaveChanges();
            }
                   
        }

        public async Task DeleteAsync(object key)
        {
            var entityToRemove = context.Set<TEntity>().Find(key);
            if (entityToRemove != null)
            {
                context.Set<TEntity>().Remove(entityToRemove);
                await context.SaveChangesAsync();
            }

        }

        public IQueryable<TEntity> Retrieve()
        {
            return context.Set<TEntity>();
        }


        public TEntity Retrieve(object id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> RetrieveAsync(object id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }



        public TEntity Update(object key, TEntity entity)
        {
            var entityToUpdate = context.Set<TEntity>()
                                        .Find(key);
            if (entityToUpdate != null)
            {
                context.Entry<TEntity>(entityToUpdate)
                       .CurrentValues
                       .SetValues(entity);
                context.SaveChanges();
            }
            return entityToUpdate;

        }

        public async Task<TEntity> UpdateAsync(object key, TEntity entity)
        {
            var entityToUpdate = await context.Set<TEntity>()
                                        .FindAsync(key);
            if (entityToUpdate != null)
            {
                context.Entry<TEntity>(entityToUpdate)
                       .CurrentValues
                       .SetValues(entity);
                await context.SaveChangesAsync();
            }
            return entityToUpdate;

        }
    }
}
