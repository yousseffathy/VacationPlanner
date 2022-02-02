using MongoDB.Bson;
using MongoDB.Driver;
using Vacation.Entities;

namespace Vacation.Repositories{
    public class MongoDbPlannedRepository : IPlannedRepository
    {
        private const string databaseName = "vacation";
        private const string collectionName = "plannedVacations";
        private readonly IMongoCollection<PlannedVacation> plannedVacationCollection;
        public MongoDbPlannedRepository(IMongoClient mongoClient){
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            plannedVacationCollection = database.GetCollection<PlannedVacation>(collectionName);
        }
        public async Task CreatePlannedVacationAsync(PlannedVacation vacation)
        {
            await plannedVacationCollection.InsertOneAsync(vacation);
        }

        public async Task DeletePlannedVacationAsync(Guid id)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(vacation => vacation.id, id);
            await plannedVacationCollection.DeleteOneAsync(filter);

        }

        public async Task<PlannedVacation> GetPlannedVacationAsync(Guid id)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(vacation => vacation.id, id);
            return await plannedVacationCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<PlannedVacation>> GetPlannedVacationsAsync()
        {
            return await plannedVacationCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdatePlannedVacationAsync(PlannedVacation vacation)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(existingVacation => existingVacation.id, vacation.id);
            await plannedVacationCollection.ReplaceOneAsync(filter, vacation);

        }
    }
}