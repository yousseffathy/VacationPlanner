using Vacation.Entities;

namespace Vacation.Repositories{
    public interface IDestinationsRepository{
        IEnumerable<Destination> GetDestinations();
        IEnumerable<Destination> GetFilteredDestinations(string month, decimal min, decimal max);
        void CreateDestination(Destination destination);
    }
}