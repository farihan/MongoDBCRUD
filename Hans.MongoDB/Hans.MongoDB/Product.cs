using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.MongoDB
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId ProductID { get; set; }
        [BsonElement("name")]
        public string ProductName { get; set; }
        [BsonElement("supplier_id")]
        public ObjectId SupplierID { get; set; }
        [BsonElement("category_id")]
        public ObjectId CategoryID { get; set; }
        [BsonElement("unit_quantity")]
        public string QuantityPerUnit { get; set; }
        [BsonElement("unit_price")]
        public decimal UnitPrice { get; set; }
        [BsonElement("stock")]
        public int UnitsInStock { get; set; }
        [BsonElement("ordered")]
        public int UnitsOnOrder { get; set; }
        [BsonElement("reorder_level")]
        public int ReorderLevel { get; set; }
        [BsonElement("discontinued")]
        public bool Discontinued { get; set; }
    }
}
