using MongoDB.Driver;
using Product.API.Entities;
using Product.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings  settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<ProductEntity>(settings.CollectionName);
        }
        public IMongoCollection<ProductEntity> Products { get; }
    }
}
