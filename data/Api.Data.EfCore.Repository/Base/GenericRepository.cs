using Api.Data.EfCore.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.EfCore.Repository.Base
{
    public abstract class GenericRepository<T> : IDataRepository<T>
        where T : BaseEntity
    {
        protected readonly EmployeeContext Context;
        protected readonly DbSet<T> Entities;

        public GenericRepository(EmployeeContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        #region Create
        public bool Add(T entity)
        {
            Entities.Add(entity);

            return Save();
        }

        public async Task<bool> AddAsync(T entity)
        {
            Entities.Add(entity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Read
        public T Get(Guid id)
        {
            return Entities.Find(id);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Entities.FindAsync(id).ConfigureAwait(false);
        }

        public List<T> GetAll()
        {
            return Entities.AsNoTracking().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
        #endregion

        #region Update
        public bool Update(T updatedEntity)
        {
            Entities.Update(updatedEntity);

            return Save();
        }

        public async Task<bool> UpdateAsync(T updatedEntity)
        {
            Entities.Update(updatedEntity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Delete
        public bool Delete(Guid id)
        {
            var entity = Entities.Find(id);
            Entities.Remove(entity);

            return Save();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await Entities.FindAsync(id).ConfigureAwait(false);
            Entities.Remove(entity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Save
        protected bool Save()
        {
            var result = Context.SaveChanges();

            return result > 0;
        }

        protected async Task<bool> SaveAsync()
        {
            var result = await Context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
        #endregion
    }
}
