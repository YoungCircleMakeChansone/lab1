using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lab.MongoModels
{
    public class MongoEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        public string Name { get; set; }
        public string Format { get; set; }
        public string Sport { get; set; }

    }
}
