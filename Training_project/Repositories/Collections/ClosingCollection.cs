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
    public class ClosingCollection : IClosingCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Closing> Collection;

        public ClosingCollection()
        {
            Collection = _repository.db.GetCollection<Closing>("Closing");
        }

        public async Task<List<Closing>> GetAllClosing()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<List<Closing>> GetClosingByDate(DateTime date)
        {
            var query = Builders<Closing>.Filter.Eq(c => c.Date, date);
            return await Collection.FindAsync(query).Result.ToListAsync();
        }

        public async Task InsertClosing(Closing closing)
        {
            await Collection.InsertOneAsync(closing);
        }
    }
}
