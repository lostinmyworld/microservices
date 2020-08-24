using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.EfCore.Repository.Base
{
    public interface IDataRepository<T>
    {
        Task<bool> Add(T entity);

        Task<List<T>> GetAll();
        Task<T> Get(long id);

        Task<bool> Update(T updatedEntity);

        Task<bool> Delete(long id);
    }
}
