using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Domain;

namespace VKEshop.Catalog.Application.Contracts.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByName(string name);
    }
}
