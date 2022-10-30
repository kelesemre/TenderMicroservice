using Product.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<ProductEntity> GetProduct(string id);
        Task<IEnumerable<ProductEntity>> GetProductByName(string name);
        Task<IEnumerable<ProductEntity>> GetProductByCategory(string categoryName);

        Task Create(ProductEntity product);
        Task<bool> Update(ProductEntity product);
        Task<bool> Delete(string id);
    }
}
