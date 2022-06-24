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
    public class WorkSpaceCollection : IWorkSpaceCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<WorkSpace> Collection;

        public WorkSpaceCollection()
        {
            Collection = _repository.db.GetCollection<WorkSpace>("WorkSpace");
        }
        public async Task DeleteWorkSpace(string id)
        {
            var filter = Builders<WorkSpace>.Filter.Eq(WorkSpace => WorkSpace.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<WorkSpace>> GetAllWorkSpaces()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public Task<List<WorkSpace>> GetWorkSpaceById(string id)
        {
            throw new NotImplementedException();
        }

        public Task InsertWorkSpace(WorkSpace workSpace)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWorkSpace(WorkSpace workSpace)
        {
            throw new NotImplementedException();
        }
    }
}
