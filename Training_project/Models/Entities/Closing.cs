using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class Closing
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
