using lab.MongoContext;
using lab.MongoModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab.Repositories
{
    public class MongoRepository
    {
        private MongoDbContext _db;

        public MongoRepository( MongoDbContext context)
        {
            _db = context;
        }

        public void AddEvent(MongoEvent item)
        {
            _db.CollectionEvents.InsertOne(item);
        }
        public void AddSport(MongoSport item)
        {
            _db.CollectionSports.InsertOne(item);
        }
        public IEnumerable<MongoEvent> GettAllSports()
        {
            var events = _db.CollectionEvents.Find(new BsonDocument()).ToList();

            return events;
        }

        public IEnumerable<MongoSport> GetAllSports()
        {
            var sports = _db.CollectionSports.Find(new BsonDocument()).ToList();

            return sports;
        }

        public MongoEvent GetEvent(string id)
        {
            var events = _db.CollectionEvents.Find(new BsonDocument()).ToList();

            var filter = Builders<MongoEvent>.Filter.Eq("_id", ObjectId.Parse(id));
            var item = _db.CollectionEvents.Find(filter).FirstOrDefault();
            return item;
        }

        public MongoSport GetSport(string id)
        {
            var sports = _db.CollectionSports.Find(new BsonDocument()).ToList();

            var filter = Builders<MongoSport>.Filter.Eq("_id", ObjectId.Parse(id));
            var item = _db.CollectionSports.Find(filter).FirstOrDefault();
            return item;
        }
    } 
}
