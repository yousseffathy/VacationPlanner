using Vacation.Entities;

namespace Vacation.Repositories{
    public interface IPlannedRepository{
        Task<IEnumerable<PlannedVacation>> GetPlannedVacationsAsync();

        Task<PlannedVacation> GetPlannedVacationAsync(Guid id);

        Task CreatePlannedVacationAsync(PlannedVacation vacation);

        Task UpdatePlannedVacationAsync(PlannedVacation vacation);
        Task DeletePlannedVacationAsync(Guid id);
    }
}