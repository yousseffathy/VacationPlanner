using Vacation.Entities;
using System.Text.Json;


namespace Vacation.Repositories
{
    
    public class InMemDestinationsRepository : IDestinationsRepository
    {
        public static string LocalJson()
        {
            string jsonString = File.ReadAllText("C:/Users/youss/Desktop/VacationRecommendation/Vacation/Repositories/temp.json");
            return jsonString;
        }
        private readonly List<Destination> destinations = JsonSerializer.Deserialize<List<Destination>>(LocalJson());

        public IEnumerable<Destination> GetDestinations(){
            return destinations;
        }

        public IEnumerable<Destination> GetFilteredDestinations(string month, decimal min, decimal max){
            return destinations.Where(destination => destination.Jan >= min && destination.Jan <= max);
        }

        public void CreateDestination(Destination destination)
        {
            destinations.Add(destination);
        }
    }
}