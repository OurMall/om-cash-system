using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;
using Training_project.Models.Interfaces;

namespace Training_project.Repositories.Collections
{
    public class ProductCollection:IProductCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Product> Collection;

        public ProductCollection()
        {
            Collection = _repository.db.GetCollection<Product>("Products");
        }

        public async Task DeleteProduct(string code)
        {
            var filter = Builders<Product>.Filter.Eq(product => product.Code, code);
            await Collection.DeleteOneAsync(filter);

        }

            
        public async Task<List<Product>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }


        public async Task<List<Product>> GetProductById(string name)
        {

            try
            {
                var query = Builders<Product>.Filter.Eq(product => product.Name, name);
                return await Collection.FindAsync(query).Result.ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Message" + e.Message);
            }
        }

        public async Task InsertProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }


        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(p => p.Code, product.Code);

            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
