using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lab.MongoModels
{
    public class MongoSport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
