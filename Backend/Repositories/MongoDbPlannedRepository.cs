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
        public void CreatePlannedVacation(PlannedVacation vacation)
        {
            plannedVacationCollection.InsertOne(vacation);
        }

        public void DeletePlannedVacation(Guid id)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(vacation => vacation.id, id);
            plannedVacationCollection.DeleteOne(filter);

        }

        public PlannedVacation GetPlannedVacation(Guid id)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(vacation => vacation.id, id);
            return plannedVacationCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<PlannedVacation> GetPlannedVacations()
        {
            return plannedVacationCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdatePlannedVacation(PlannedVacation vacation)
        {
            var filter = Builders<PlannedVacation>.Filter.Eq(existingVacation => existingVacation.id, vacation.id);
            plannedVacationCollection.ReplaceOne(filter, vacation);

        }
    }
}