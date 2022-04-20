using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training_project.Models.Entities
{
    [BsonIgnoreExtraElements]
    public class Invoice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Id_client { get; set; }
        public List<Invoice_details> Details { get; set; }
        public string Payment_method { get; set; }
        public double Total_price { get; set; }
    }
}
