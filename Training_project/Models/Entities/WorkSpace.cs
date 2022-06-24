using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class WorkSpace
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Id_categorie { get; set; }
        public string Tags { get; set; }
        public string Logo { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Create_at { get; set; }

    }
}
