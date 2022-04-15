using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Models.Entities
{
    public class Invoice_details
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<Product> Products { get; set; }
        public double Total_price { get; set; }
    }
}
