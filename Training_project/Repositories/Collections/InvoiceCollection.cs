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
    public class InvoiceCollection : IInvoiceCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Invoice> Collection;

        public InvoiceCollection()
        {
            Collection = _repository.db.GetCollection<Invoice>("Invoices");
        }

        public async Task DeleteInvoice(string id)
        {
            var filter = Builders<Invoice>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertInvoice(Invoice invoice)
        {
            
             await Collection.InsertOneAsync(invoice);
            
            
        }


        public async Task UpdateInvoice(Invoice invoice)
        {
            var filter = Builders<Invoice>
                .Filter
                .Eq(s => s.Id, invoice.Id);

            await Collection.ReplaceOneAsync(filter, invoice);
        }
    }
}
