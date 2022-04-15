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
    public class DetailsCollection: IInvoice_detailsCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Invoice_details> Collection;

        public DetailsCollection()
        {
            Collection = _repository.db.GetCollection<Invoice_details>("Details");
        }

        public async Task DeleteDetails(string id)
        {
            var filter = Builders<Invoice_details>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Invoice_details>> GetAllDetails()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Invoice_details> GetDetailsById(string id)
        {
            return await Collection.FindAsync(
               new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();

        }

        public async Task InsertDetails(Invoice_details details)
        {
            await Collection.InsertOneAsync(details);
        }

        public async Task UpdateDetails(Invoice_details details)
        {
            var filter = Builders<Invoice_details>
                .Filter
                .Eq(s => s.Id, details.Id);

            await Collection.ReplaceOneAsync(filter, details);
        }
    }
}
