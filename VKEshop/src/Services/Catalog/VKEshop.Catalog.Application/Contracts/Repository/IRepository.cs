using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Contracts.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {

        //Dikkat!!! Repository'nin derdi data storage.
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);

        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);



        
    }
}
