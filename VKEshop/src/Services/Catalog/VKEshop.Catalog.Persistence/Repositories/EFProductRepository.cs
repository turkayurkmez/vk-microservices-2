using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;
using VKEshop.Catalog.Domain;
using VKEshop.Catalog.Persistence.Data;

namespace VKEshop.Catalog.Persistence.Repositories
{
    public class EFProductRepository(VKEshopCatalogDb dbContext) : IProductRepository
    {

        public async Task Create(Product entity)
        {
            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deletingProduct = await dbContext.Products.FindAsync(id);
            dbContext.Products.Remove(deletingProduct);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await dbContext.Products.ToListAsync();
            return products.AsEnumerable();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> SearchByName(string name)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task Update(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
