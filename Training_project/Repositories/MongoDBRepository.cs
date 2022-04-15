using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            try
            {
                client = new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");

                db = client.GetDatabase("Invoice");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }

        }
    }
}