using MongoDB.Bson;
using MongoDB.Driver;
using Vacation.Entities;
using DynamicExpressions;

namespace Vacation.Repositories{
    public class MongoDbDestinationsRepository : IDestinationsRepository
    {
        private const string databaseName = "vacation";
        private const string collectionName = "Destinations";
        private readonly IMongoCollection<Destination> destinationsCollection;
        public MongoDbDestinationsRepository(IMongoClient mongoClient){
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            destinationsCollection = database.GetCollection<Destination>(collectionName);
        }

        public async Task CreateDestinationAsync(Destination destination)
        {
            await destinationsCollection.InsertOneAsync(destination);
        }

        public async Task<IEnumerable<Destination>> GetDestinationsAsync()
        {
            return await destinationsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<Destination>> GetFilteredDestinationsAsync(string month, decimal min, decimal max)
        {
            var predicate = new DynamicFilterBuilder<Destination>()
            .And(b => b.And(month, FilterOperator.GreaterThanOrEqual, min))
            .And(b => b.And(month, FilterOperator.LessThanOrEqual, max))
            .Build();
            return await destinationsCollection.Find(predicate).ToListAsync();

        }
    }
}