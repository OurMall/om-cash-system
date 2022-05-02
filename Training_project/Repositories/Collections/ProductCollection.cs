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

        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }


        public async Task<List<Product>> GetProductById(string id)
        {
            var query = Builders<Product>.Filter.Eq(p => p.Code, id);
            return await Collection.FindAsync(query).Result.ToListAsync();
            /*return await Collection.FindAsync(
             * 
             *             var options = new FindOptions<Product>()
            {
                Projection = Builders<Product>.Projection
                .Include(p => p.Name).Include(p => p.Price).Exclude(p => p.Quantity).Exclude(p => p.Id)
            
            };

            var result = await Collection.FindAsync(query, options);
               new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
            */
        }

        public async Task InsertProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }


        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>
                .Filter
                .Eq(s => s.Id, product.Id);

            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
