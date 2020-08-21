using Api.Base.Web.Exceptions;
using Api.Data.EfCore.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.EfCore.Repository.Base
{
    public abstract class GenericRepository<T> : IDataRepository<T>
        where T : BaseEntity
    {
        protected readonly EntityContext Context;
        protected readonly DbSet<T> Entities;

        public GenericRepository(EntityContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        #region Create
        public async Task<bool> Add(T entity)
        {
            Entities.Add(entity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Read
        public async Task<T> Get(long id)
        {
            return await Entities.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<List<T>> GetAll()
        {
            return await Entities.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
        #endregion

        #region Update
        public async Task<bool> Update(long id, T updatedEntity)
        {
            if (updatedEntity == default)
            {
                throw new RequestParamNullException();
            }

            var dbEntity = await Get(id).ConfigureAwait(false);
            if (dbEntity == default)
            {
                throw new EntityNotFoundException();
            }

            Entities.Update(updatedEntity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(long id)
        {
            var dbEntity = await Get(id).ConfigureAwait(false);
            if (dbEntity == default)
            {
                throw new EntityNotFoundException();
            }

            Entities.Remove(dbEntity);

            return await SaveAsync().ConfigureAwait(false);
        }
        #endregion

        #region Save
        protected async Task<bool> SaveAsync()
        {
            var result = await Context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }
        #endregion
    }
}
