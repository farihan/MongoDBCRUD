using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.MongoDB
{
    public class Mosque
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId ID { get; set; }

        [BsonElement("nama")]
        public string Name { get; set; }

        [BsonElement("alamat")]
        public string Address { get; set; }

        [BsonElement("poskod")]
        public string Postcode { get; set; }

        [BsonElement("negeri")]
        public string State { get; set; }

        [BsonElement("daerah")]
        public string District { get; set; }

        [BsonElement("telefon")]
        public string Contact { get; set; }

        [BsonElement("jenis")]
        public string Type { get; set; }
    }
}
