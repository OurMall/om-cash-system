using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public List<string> Questions { get; set; }
        public List<string> Images { get; set; }
        public bool Is_available { get; set; }
        public DateTime Create_at { get; set; }

    }
}
