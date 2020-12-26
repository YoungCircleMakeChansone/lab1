using lab.Interfaces;
using lab.MongoModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.IO;

namespace lab.MongoContext
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private IMongoClient _mongoClient { get; set; }


        public MongoDbContext()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");

            _db = _mongoClient.GetDatabase("sportEventDb");
        }
        public IMongoCollection<MongoEvent> CollectionEvents
        {
            get => _db.GetCollection<MongoEvent>("Event");
        }

        public IMongoCollection<MongoSport> CollectionSports
        {
            get => _db.GetCollection<MongoSport>("Sport");
        }
    }
}
