using Vacation.Entities;

namespace Vacation.Repositories{
    public interface IDestinationsRepository{
        Task<IEnumerable<Destination>> GetDestinationsAsync();
        Task<IEnumerable<Destination>> GetFilteredDestinationsAsync(string month, decimal min, decimal max);
        Task CreateDestinationAsync(Destination destination);
    }
}