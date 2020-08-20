using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.EfCore.Repository.Base
{
    public interface IDataRepository<T>
    {
        #region Create
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        #endregion

        #region Read
        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        T Get(Guid id);
        Task<T> GetAsync(Guid id);
        #endregion

        #region Update
        bool Update(T updatedEntity);
        Task<bool> UpdateAsync(T updatedEntity);
        #endregion

        #region Delete
        bool Delete(Guid id);
        Task<bool> DeleteAsync(Guid id);
        #endregion
    }
}
