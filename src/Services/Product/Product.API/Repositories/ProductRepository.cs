using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;
        public ProductRepository(IProductContext context)
        {
            _context = context;
        }
        public async Task Create(ProductEntity product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<ProductEntity> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<ProductEntity>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByName(string name)
        {
            var filter = Builders<ProductEntity>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(ProductEntity product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<int> BlaBla() {
            var filter = Builders<ProductEntity>.Filter.Eq(m => m.Id, "1");
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            return 3;
        }
    }
}
